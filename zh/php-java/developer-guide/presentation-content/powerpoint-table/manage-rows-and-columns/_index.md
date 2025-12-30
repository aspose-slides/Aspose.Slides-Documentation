---
title: 使用 PHP 在 PowerPoint 表格中管理行和列
linktitle: 行和列
type: docs
weight: 20
url: /zh/php-java/manage-rows-and-columns/
keywords:
- 表格行
- 表格列
- 首行
- 表头
- 克隆行
- 克隆列
- 复制行
- 复制列
- 删除行
- 删除列
- 行文本格式
- 列文本格式
- 表格样式
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（通过 Java）管理 PowerPoint 表格的行和列，并加快演示文稿的编辑和数据更新。"
---

为了让您能够在 PowerPoint 演示文稿中管理表格的行和列，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 类、[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 接口和许多其他类型。

## **设置第一行作为标题**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例并加载演示文稿。  
2. 通过索引获取幻灯片的引用。  
3. 创建一个 [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 对象并将其设为 null。  
4. 遍历所有 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) 对象以查找相应的表格。  
5. 将表格的第一行设置为标题行。  

以下 PHP 代码演示如何将表格的第一行设置为标题行：
```php
  # 实例化 Presentation 类
  $pres = new Presentation("table.pptx");
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 初始化 null TableEx
    $tbl = null;
    # 遍历形状并将引用设置为表格
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # 将表格的第一行设为标题
        $tbl->setFirstRow(true);
      }
    }
    # 将演示文稿保存到磁盘
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **克隆表格的行或列**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例并加载演示文稿，  
2. 通过索引获取幻灯片的引用。  
3. 定义 `columnWidth` 数组。  
4. 定义 `rowHeight` 数组。  
5. 通过 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---) 方法向幻灯片添加一个 [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 对象。  
6. 克隆表格行。  
7. 克隆表格列。  
8. 保存修改后的演示文稿。  

以下 PHP 代码演示如何克隆 PowerPoint 表格的行或列：
```php
  # 实例化 Presentation 类
  $pres = new Presentation("Test.pptx");
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 定义列宽度和行高度
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # 向幻灯片添加表格形状
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 向第1行第1列添加文本
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # 向第1行第2列添加文本
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # 在表格末尾克隆第1行
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # 向第2行第1列添加文本
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # 向第2行第2列添加文本
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # 将第2行克隆为表格第4行
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # 在末尾克隆第一列
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # 在第4列位置克隆第二列
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # 将演示文稿保存到磁盘
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **从表格中删除行或列**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例并加载演示文稿，  
2. 通过索引获取幻灯片的引用。  
3. 定义 `columnWidth` 数组。  
4. 定义 `rowHeight` 数组。  
5. 通过 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---) 方法向幻灯片添加一个 [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 对象。  
6. 删除表格行。  
7. 删除表格列。  
8. 保存修改后的演示文稿。  

以下 PHP 代码演示如何从表格中删除行或列：
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置表格行级别的文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例并加载演示文稿，  
2. 通过索引获取幻灯片的引用。  
3. 从幻灯片中访问相应的 [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 对象。  
4. 设置第一行单元格的 [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-)。  
5. 设置第一行单元格的 [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) 和 [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-)。  
6. 设置第二行单元格的 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)。  
7. 保存修改后的演示文稿。  

以下 PHP 代码演示此操作。
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 假设第一张幻灯片上的第一个形状是表格
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 设置第一行单元格的字体高度
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # 设置第一行单元格的文本对齐方式和右边距
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # 设置第二行单元格的文本垂直类型
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # 将演示文稿保存到磁盘
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置表格列级别的文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例并加载演示文稿，  
2. 通过索引获取幻灯片的引用。  
3. 从幻灯片中访问相应的 [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) 对象。  
4. 设置第一列单元格的 [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-)。  
5. 设置第一列单元格的 [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) 和 [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-)。  
6. 设置第二列单元格的 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)。  
7. 保存修改后的演示文稿。  

以下 PHP 代码演示此操作：
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 假设第一张幻灯片上的第一个形状是表格
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 设置第一列单元格的字体高度
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # 在一次调用中设置第一列单元格的文本对齐方式和右边距
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # 设置第二列单元格的文本垂直类型
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，从而可以将这些细节用于其他表格或其他位置。以下 PHP 代码演示如何从表格预设样式中获取样式属性：
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// 更改默认的样式预设主题

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**我可以将 PowerPoint 主题/样式应用于已经创建的表格吗？**  

是的。表格会继承幻灯片/布局/母版的主题，您仍然可以在此主题之上覆盖填充、边框和文本颜色。

**我可以像在 Excel 中一样对表格行进行排序吗？**  

不行，Aspose.Slides 表格没有内置的排序或筛选功能。请先在内存中对数据进行排序，然后按该顺序重新填充表格行。

**我可以在保持特定单元格自定义颜色的同时使用交错（条纹）列吗？**  

可以。开启交错列后，仍然可以对特定单元格使用本地格式设置；单元格级别的格式会优先于表格样式。