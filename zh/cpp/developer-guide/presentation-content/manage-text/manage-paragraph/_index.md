---
title: 在 C++ 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/cpp/manage-paragraph/
keywords:
- 添加文本
- 添加段落
- 管理文本
- 管理段落
- 管理项目符号
- 段落缩进
- 悬挂缩进
- 段落项目符号
- 编号列表
- 项目符号列表
- 段落属性
- 导入 HTML
- 文本转 HTML
- 段落转 HTML
- 段落转图像
- 文本转图像
- 导出段落
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: 使用 Aspose.Slides for C++ 完成段落格式化的高级操作——在 PPT、PPTX 和 ODP 演示文稿中优化对齐、间距和样式（C++）。
---
Aspose.Slides 提供了在 C++ 中处理 PowerPoint 文本、段落和部分所需的所有接口和类。

* Aspose.Slides 提供了 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 接口，允许您添加表示段落的对象。一个 `ITextFame` 对象可以包含一个或多个段落（每个段落通过回车创建）。
* Aspose.Slides 提供了 [IParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/) 接口，允许您添加表示部分的对象。一个 `IParagraph` 对象可以包含一个或多个部分（iPortions 对象的集合）。
* Aspose.Slides 提供了 [IPortion](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/) 接口，允许您添加表示文本及其格式属性的对象。 

`IParagraph` 对象能够通过其底层的 `IPortion` 对象处理具有不同格式属性的文本。

## **添加包含多个部分的多个段落**

以下步骤演示如何添加一个包含 3 个段落且每个段落包含 3 个部分的文本框：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取相应幻灯片的引用。  
3. 向幻灯片添加一个矩形 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。  
4. 获取与 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 关联的 ITextFrame。  
5. 创建两个 [IParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/) 对象，并将它们添加到 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 的 `IParagraphs` 集合中。  
6. 为每个新的 `IParagraph` 创建三个 [IPortion](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/) 对象（默认段落创建两个 Portion 对象），并将每个 `IPortion` 对象添加到相应 `IParagraph` 的 IPortion 集合中。  
7. 为每个部分设置一些文本。  
8. 使用 `IPortion` 对象公开的格式属性，为每个部分应用您喜欢的格式设置。  
9. 保存修改后的演示文稿。  

```c++
// 文档目录的路径。
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 添加矩形类型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// 为矩形添加 TextFrame
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// 访问第一个段落
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// 添加第二个段落
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// 添加第三个段落
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// 将 PPTX 保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **管理段落项目符号**

项目符号列表帮助您快速高效地组织和呈现信息。使用项目符号的段落更易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取相应幻灯片的引用。  
3. 向选定的幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。  
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。  
5. 删除 `TextFrame` 中的默认段落。  
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/paragraph/) 类创建第一个段落实例。  
7. 将段落的项目符号 `Type` 设置为 `Symbol` 并设置项目符号字符。  
8. 设置段落的 `Text`。  
9. 为项目符号设置段落的 `Indent`。  
10. 为项目符号设置颜色。  
11. 设置项目符号的高度。  
12. 将新段落添加到 `TextFrame` 的段落集合中。  
13. 添加第二个段落并重复步骤 7 到 13。  
14. 保存演示文稿。  

```c++
// 文档目录的路径。
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 添加矩形类型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// 为矩形添加 TextFrame
ashp->AddTextFrame(u"");

// 正在访问文本框
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// 为文本框创建 Paragraph 对象
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// 设置文本
paragraph->set_Text(u"Welcome to Aspose.Slides");

// 设置项目符号缩进
paragraph->get_ParagraphFormat()->set_Indent (25);

// 设置项目符号颜色
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// 将 IsBulletHardColor 设为 true 以使用自定义项目符号颜色
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// 设置项目符号高度
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// 将段落添加到文本框
txtFrame->get_Paragraphs()->Add(paragraph);

// 创建第二个段落
// 为文本框创建 Paragraph 对象
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// 设置文本
paragraph2->set_Text(u"This is numbered bullet");

// 设置段落项目符号类型和样式
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// 设置项目符号缩进
paragraph2->get_ParagraphFormat()->set_Indent(25);

// 设置项目符号颜色
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// 将 IsBulletHardColor 设为 true 以使用自定义项目符号颜色
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// 设置项目符号高度
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// 将段落添加到文本框
txtFrame->get_Paragraphs()->Add(paragraph2);


// 将 PPTX 保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **管理图片项目符号**

项目符号列表帮助您快速高效地组织和呈现信息。图片段落易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取相应幻灯片的引用。  
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。  
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。  
5. 删除 `TextFrame` 中的默认段落。  
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/paragraph/) 类创建第一个段落实例。  
7. 在 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/) 中加载图像。  
8. 将项目符号类型设置为 [Picture](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/) 并设置图像。  
9. 设置段落的 `Text`。  
10. 为项目符号设置段落的 `Indent`。  
11. 为项目符号设置颜色。  
12. 设置项目符号的高度。  
13. 将新段落添加到 `TextFrame` 的段落集合中。  
14. 添加第二个段落并根据前面的步骤重复操作。  
15. 保存修改后的演示文稿。  

```c++
// 实例化一个表示 PPTX 文件的 Presentation 类
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// 访问第一张幻灯片
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 实例化项目符号图片
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// 添加并访问 AutoShape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 访问 AutoShape 的 TextFrame
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// 删除默认段落
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// 创建新段落
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// 设置段落项目符号样式和图片
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// 设置项目符号高度
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// 将段落添加到 TextFrame
paragraphs->Add(paragraph);

// 将演示文稿保存为 PPTX 文件
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// 将演示文稿保存为 PPT 文件
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **管理多级项目符号**

项目符号列表帮助您快速高效地组织和呈现信息。多级项目符号易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取相应幻灯片的引用。  
3. 在新幻灯片中添加一个 [autoshape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。  
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。  
5. 删除 `TextFrame` 中的默认段落。  
6. 通过 [Paragraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/paragraph/) 类创建第一个段落实例，并将深度设为 0。  
7. 通过 `Paragraph` 类创建第二个段落实例，并将深度设为 1。  
8. 通过 `Paragraph` 类创建第三个段落实例，并将深度设为 2。  
9. 通过 `Paragraph` 类创建第四个段落实例，并将深度设为 3。  
10. 将新段落添加到 `TextFrame` 的段落集合中。  
11. 保存修改后的演示文稿。  

```c++
// 实例化一个表示 PPTX 文件的 Presentation 类
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 访问第一张幻灯片
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// 添加并访问 AutoShape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 访问创建的 AutoShape 的 TextFrame
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// 清除默认段落
text->get_Paragraphs()->Clear();

// 添加第一个段落
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 设置项目符号级别
para1Format->set_Depth(0);

// 添加第二个段落
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 设置项目符号级别
para2Format->set_Depth(1);

// 添加第三个段落
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 设置项目符号级别
para3Format->set_Depth(2);

// 添加第四个段落
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 设置项目符号级别
para4Format->set_Depth(3);

// 将段落添加到集合中
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// 将演示文稿保存为 PPTX 文件
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **管理具有自定义编号列表的段落**

[IBulletFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/) 接口提供了 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 属性等，可帮助您管理具有自定义编号或格式的段落。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 访问包含该段落的幻灯片。  
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。  
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。  
5. 删除 `TextFrame` 中的默认段落。  
6. 通过 [Paragraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/paragraph/) 类创建第一个段落实例，并将 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 设为 2。  
7. 通过 `Paragraph` 类创建第二个段落实例，并将 `NumberedBulletStartWith` 设为 3。  
8. 通过 `Paragraph` 类创建第三个段落实例，并将 `NumberedBulletStartWith` 设为 7。  
9. 将新段落添加到 `TextFrame` 的段落集合中。  
10. 保存修改后的演示文稿。  

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 访问已创建的 AutoShape 的文本框
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// 删除默认的现有段落
textFrame->get_Paragraphs()->RemoveAt(0);

// 第一个列表
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **设置段落的首行缩进**

使用 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/) 方法可控制段落的首行缩进。此方法仅移动相对于段落左边距的第一行。正值会将首行向右移动，而其余行保持与段落正文对齐。

当需要移动整个段落时请使用 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_marginleft/)。仅需移动首行时请使用 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/)。

下面的示例创建多个段落并为它们设置不同的 `Indent` 值，以演示首行缩进对段落布局的影响。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 访问目标幻灯片。  
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/autoshape/)。  
4. 向形状添加一个空的 [TextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/textframe/)，并删除默认段落。  
5. 创建若干段落并为它们设置不同的 [Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/) 值。  
6. 将段落添加到文本框中。  
7. 保存修改后的演示文稿。  

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![The first-line indent of the paragraphs](first_line_indent.png)

## **设置段落的悬挂缩进**

悬挂缩进是一种段落布局，第一行位于其余行的左侧。在 Aspose.Slides 中，可使用 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/) 方法实现。将缩进设为负值即可将第一行向左移动。

实际使用中，[IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_marginleft/) 定义段落正文的左侧位置，而 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/) 定义第一行相对于该左侧的位移。要创建悬挂缩进，请将 `MarginLeft` 设为正值并将 `Indent` 设为负值。

此格式常用于参考文献、词汇表条目等需要让换行行对齐在正文左侧而非首行字符左侧的段落。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 访问目标幻灯片。  
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/autoshape/)。  
4. 向形状添加一个空的 [TextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/textframe/)，并删除默认段落。  
5. 为每个段落创建并设置正的 [MarginLeft](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_marginleft/) 值。  
6. 设置负的 [Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/) 值以产生悬挂缩进效果。  
7. 将段落添加到文本框中。  
8. 保存修改后的演示文稿。  

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![The hanging indent of the paragraphs](hanging_indent.png)

## **管理段落结束运行属性**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
1. 通过位置获取包含该段落的幻灯片的引用。  
1. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。  
1. 向矩形添加一个带有两个段落的 [TextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。  
1. 为段落设置 `FontHeight` 和字体类型。  
1. 为段落设置结束属性。  
1. 将修改后的演示文稿写入为 PPTX 文件。  

```c++
// 文档目录的路径。
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 添加矩形类型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// 为矩形添加 TextFrame
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// 添加第一个段落
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// 添加第二个段落
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// 将 PPTX 保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **将 HTML 文本导入段落**

Aspose.Slides 提供了增强的 HTML 文本导入段落的支持。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取相应幻灯片的引用。  
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。  
4. 添加并访问 `autoshape` 的 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。  
5. 删除 `ITextFrame` 中的默认段落。  
6. 在 TextReader 中读取源 HTML 文件。  
7. 通过 [Paragraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/paragraph/) 类创建第一个段落实例。  
8. 将读取的 TextReader 中的 HTML 内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/paragraphcollection/)。  
9. 保存修改后的演示文稿。  

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// 文档目录的路径。
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 添加矩形类型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//重置默认填充颜色
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// 为矩形添加 TextFrame
ashp->AddTextFrame(u" ");

// 正在访问文本框
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//获取 Paragraphs 集合
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// 清除已添加文本框中的所有段落
ParaCollection->Clear();

// 使用流读取器加载 HTML 文件
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// 将 HTML 流读取器中的文本添加到文本框
ParaCollection->AddFromHtml(tr->ReadToEnd());


// 为文本框创建 Paragraph 对象
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// 为段落创建 Portion 对象
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//获取 Portion 格式
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// 为 Portion 设置字体
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// 设置字体的粗体属性
pf->set_FontBold(NullableBool::True);

// 设置字体的斜体属性
pf->set_FontItalic(NullableBool::True);

// 设置字体的下划线属性
pf->set_FontUnderline(TextUnderlineType::Single);

// 设置字体的高度
pf->set_FontHeight(25);

// 设置字体的颜色
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// 将 PPTX 保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **导出段落文本为 HTML**

Aspose.Slides 提供了增强的将段落文本导出为 HTML 的支持。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例并加载所需的演示文稿。  
2. 通过索引获取相应幻灯片的引用。  
3. 访问包含要导出为 HTML 的文本的形状。  
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。  
5. 创建 `StreamWriter` 实例并添加新的 HTML 文件。  
6. 为 StreamWriter 提供起始索引并导出您选定的段落。  

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// 文档目录的路径。
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// 访问演示文稿的默认第一页
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 目标索引
int index = 0;

// 访问添加的形状
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// 将第一个段落提取为 HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// 通过提供段落起始索引和要复制的段落总数，将段落数据写入 HTML
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **将段落保存为图像**

在本节中，我们将展示两个示例，演示如何将由 [IParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/) 接口表示的文本段落保存为图像。两者都包括使用 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) 接口的 `GetImage` 方法获取包含段落的形状图像，计算段落在形状内的边界，并将其导出为位图图像。这些方法可让您从 PowerPoint 演示文稿中提取特定文本片段并保存为单独的图像，适用于各种后续场景。

假设我们有一个名为 sample.pptx 的演示文稿，只有一张幻灯片，第一形状是包含三个段落的文本框。

![The text box with three paragraphs](paragraph_to_image_input.png)

**示例 1**

在此示例中，我们获取第二段落的图像。为此，我们先从演示文稿的第一张幻灯片中提取形状的图像，然后计算该形状文本框中第二段落的边界。随后将段落重新绘制到新的位图图像中，并以 PNG 格式保存。该方法在需要将特定段落保存为单独图像且保持文本尺寸和格式的情况下尤为有用。

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

结果：

![The paragraph image](paragraph_to_image_output.png)

**示例 2**

在此示例中，我们在前一种方法的基础上为段落图像添加了缩放因子。形状从演示文稿中提取并以缩放因子 `2` 保存为图像，从而在导出段落时获得更高分辨率。随后在考虑缩放的情况下计算段落边界。缩放在需要更高细节图像的场景（例如高质量印刷材料）中特别有用。

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap with scaling.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **FAQ**

**我能完全禁用文本框内的自动换行吗？**

可以。使用文本框的换行方法 ([set_WrapText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/textframeformat/set_wraptext/)) 将换行关闭，即行不会在框边缘换行。

**如何获取特定段落在幻灯片上的精确边界？**

您可以检索段落（甚至单个部分）的边界矩形，以了解其在幻灯片上的精确位置和大小。

**段落的对齐方式（左/右/居中/两端对齐）在哪里控制？**

[Alignment](https://reference.aspose.com/slides/zh/cpp/aspose.slides/paragraphformat/set_alignment/) 是 [ParagraphFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/paragraphformat/) 中的段落级设置；它适用于整个段落，而不受单独部分格式的影响。

**我能只为段落的一部分（例如一个单词）设置拼写检查语言吗？**

可以。语言在部分级别通过 ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/baseportionformat/set_languageid/)) 设置，因此同一段落中可以共存多种语言。