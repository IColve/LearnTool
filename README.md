将脚本放置Asset目录Editor文件夹下 入口为顶部按钮Tools/LearnWindow

阅读前需修改脚本中两个路径字段
_defaultPath ： 用来存储阅读记录下标的文件，不需关注此文件。
_learnPath ： 阅读的书籍路径。

使用方式：
unity运行场景后，
按A键，启动阅读流程，S键为下标递增，W键为下标1递减，每个下标对应10个文字。
启动阅读后，窗口中的第二个按钮的文字，会被切换为书籍中提取到的文字。
按D键，中断阅读流程，按钮文本被还原成默认文本。
