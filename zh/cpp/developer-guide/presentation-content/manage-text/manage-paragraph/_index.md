---
title: 管理 C++ 中的 PowerPoint 段落
type: docs
weight: 40
url: /cpp/manage-paragraph/
keywords: "添加 PowerPoint 段落, 管理段落, 段落缩进, 段落属性, HTML 文本, 导出段落文本, PowerPoint 演示文稿, C++, CPP, Aspose.Slides for C++"
description: "在 C++ 中创建和管理 PowerPoint 演示文稿中的段落、文本、缩进和属性"
---

Aspose.Slides 提供了所有您需要在 C++ 中处理 PowerPoint 文本、段落和部分的接口和类。

* Aspose.Slides 提供了 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 接口，以允许您添加表示段落的对象。一个 `ITextFame` 对象可以包含一个或多个段落（每个段落通过换行符创建）。
* Aspose.Slides 提供了 [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) 接口，以允许您添加表示部分的对象。一个 `IParagraph` 对象可以包含一个或多个部分（iPortions 对象的集合）。
* Aspose.Slides 提供了 [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) 接口，以允许您添加表示文本及其格式属性的对象。

一个 `IParagraph` 对象能够通过其底层的 `IPortion` 对象处理具有不同格式属性的文本。

## **添加包含多个部分的多个段落**

这些步骤向您展示如何添加一个包含 3 个段落且每个段落包含 3 个部分的文本框：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向幻灯片添加一个矩形 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
4. 获取与 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) 关联的 ITextFrame。
5. 创建两个 [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) 对象并将它们添加到 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 的 `IParagraphs` 集合中。
6. 为每个新的 `IParagraph` 创建三个 [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) 对象（两个部分对象用于默认段落），并将每个 `IPortion` 对象添加到每个 `IParagraph` 的 IPortion 集合中。
7. 为每个部分设置一些文本。
8. 使用 `IPortion` 对象公开的格式属性应用您喜欢的格式功能到每个部分。
9. 保存修改后的演示文稿。

以下 C++ 代码是实现添加包含部分的段落的步骤：

```c++
// 文档目录的路径。
const String outPath = u"../out/MultipleParagraphs_out.pptx";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 添加一个矩形类型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// 向矩形添加 TextFrame
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

项目符号列表可以帮助您快速而有效地组织和展示信息。带有项目符号的段落总是更容易阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向所选幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)。 
5. 移除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 将段落的项目符号 `Type` 设置为 `Symbol` 并设置项目符号字符。
8. 设置段落的 `Text`。
9. 设置项目符号的段落 `Indent`。
10. 为项目符号设置颜色。
11. 设置项目符号的高度。
12. 将新段落添加到 `TextFrame` 段落集合中。
13. 添加第二个段落并重复步骤 7 到 13 中的过程。
14. 保存演示文稿。

以下 C++ 代码展示了如何添加段落项目符号：

```c++
// 文档目录的路径。
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 添加一个矩形类型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// 向矩形添加 TextFrame
ashp->AddTextFrame(u"");

// 访问文本框
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// 为文本框创建段落对象
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// 设置文本
paragraph->set_Text(u"欢迎使用 Aspose.Slides");

// 设置项目符号缩进
paragraph->get_ParagraphFormat()->set_Indent (25);

// 设置项目符号颜色
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// 将 IsBulletHardColor 设置为 true 以使用自定义的项目符号颜色
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// 设置项目符号高度
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// 将段落添加到文本框
txtFrame->get_Paragraphs()->Add(paragraph);

// 创建第二个段落
// 为文本框创建段落对象
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// 设置文本
paragraph2->set_Text(u"这是带编号的项目符号");

// 设置段落项目符号类型和样式
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// 设置项目符号缩进
paragraph2->get_ParagraphFormat()->set_Indent(25);

// 设置项目符号颜色
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// 设置项目符号高度
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// 将段落添加到文本框
txtFrame->get_Paragraphs()->Add(paragraph2);

// 将 PPTX 保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **管理图片项目符号**

项目符号列表帮助您快速有效地组织和呈现信息。图片段落易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)。 
5. 移除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 在 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 中加载图像。
8. 将项目符号类型设置为 [Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 并设置图像。
9. 设置段落 `Text`。
10. 设置段落项目符号 `Indent`。
11. 设置项目符号颜色。
12. 设置项目符号的高度。
13. 将新段落添加到 `TextFrame` 段落集合中。
14. 添加第二个段落并根据之前的步骤重复该过程。
15. 保存修改后的演示文稿。

以下 C++ 代码显示您如何添加和管理图片项目符号：

```c++
// 实例化一个表示 PPTX 文件的 Presentation 类
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// 访问第一张幻灯片
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 实例化用于项目符号的图像
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// 添加并访问 AutoShape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 访问 autoshape 的文本框
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// 移除默认段落
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// 创建新段落
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"欢迎使用 Aspose.Slides");

// 设置段落项目符号样式和图像
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// 设置项目符号高度
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// 将段落添加到文本框
paragraphs->Add(paragraph);

// 将演示文稿写入 PPTX 文件
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// 将演示文稿写入 PPT 文件
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **管理多级项目符号**

项目符号列表可以帮助您快速有效地组织和展示信息。多级项目符号易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 在新幻灯片中添加一个 [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)。 
5. 移除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) 类创建第一个段落实例并将深度设置为 0。
7. 通过 `Paragraph` 类创建第二个段落实例并将深度设置为 1。
8. 通过 `Paragraph` 类创建第三个段落实例并将深度设置为 2。
9. 通过 `Paragraph` 类创建第四个段落实例并将深度设置为 3。
10. 将新段落添加到 `TextFrame` 段落集合中。
11. 保存修改后的演示文稿。

以下 C++ 代码展示了如何添加和管理多级项目符号：

```c++
// 实例化一个表示 PPTX 文件的 Presentation 类
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 访问第一张幻灯片
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// 添加并访问 AutoShape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 访问已创建的 autoshape 的文本框
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// 清除默认段落
text->get_Paragraphs()->Clear();

// 添加第一个段落
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"内容");
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
para2->set_Text(u"第二级");
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
para3->set_Text(u"第三级");
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
para4->set_Text(u"第四级");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 设置项目符号级别
para4Format->set_Depth(3);

// 将段落添加到集合
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// 将演示文稿写入 PPTX 文件
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **管理带有自定义编号列表的段落**

[IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) 接口提供了 [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 属性和其他属性，允许您管理带有自定义编号或格式的段落。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 访问包含段落的幻灯片。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)。 
5. 移除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) 类创建第一个段落实例并将 [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 设置为 2。
7. 通过 `Paragraph` 类创建第二个段落实例并将 `NumberedBulletStartWith` 设置为 3。
8. 通过 `Paragraph` 类创建第三个段落实例并将 `NumberedBulletStartWith` 设置为 7。
9. 将新段落添加到 `TextFrame` 段落集合中。
10. 保存修改后的演示文稿。

以下 C++ 代码展示了如何添加和管理带有自定义编号或格式的段落：

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 访问已创建的 autoshape 的文本框
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// 移除默认现有段落
textFrame->get_Paragraphs()->RemoveAt(0);

// 第一个列表
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"项目符号 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"项目符号 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"项目符号 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **设置段落缩进**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 通过其索引访问相关幻灯片的引用。
1. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
1. 向矩形 autoShape 添加三个段落的 [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)。
1. 隐藏矩形边框。
1. 通过其 BulletOffset 属性为每个 [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) 设置缩进。
1. 将修改后的演示文稿写入 PPT 文件。

以下 C++ 代码展示了如何设置段落缩进：

```c++
// 文档目录的路径。
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 添加一个矩形类型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// 向矩形添加 TextFrame
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

tf->get_Paragraphs()->Clear();

// 添加第一个段落
SharedPtr<Paragraph> superPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion1 = MakeObject<Portion>(u"幻灯片标题");
superPar->get_Portions()->Add(portion1);

SharedPtr<Portion> superPortion = MakeObject<Portion>();
superPortion->get_PortionFormat()->set_Escapement(30);
superPortion->set_Text(u"TM");
superPar->get_Portions()->Add(superPortion);

// 添加第一个段落
SharedPtr<Paragraph> subPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion2 = MakeObject<Portion>(u"a");
subPar->get_Portions()->Add(portion2);

SharedPtr<Portion> subPortion = MakeObject<Portion>();
subPortion->get_PortionFormat()->set_Escapement(-25);
subPortion->set_Text(u"i");
subPar->get_Portions()->Add(subPortion);

// 添加到文本框
ashp->get_TextFrame()->get_Paragraphs()->Add(superPar);
ashp->get_TextFrame()->get_Paragraphs()->Add(subPar);

// 将 PPTX 保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **设置段落的悬挂缩进**

以下 C++ 代码展示了如何设置段落的悬挂缩进：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 250.0f, 550.0f, 150.0f);

System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"示例");
System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"设置段落的悬挂缩进");
System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"这段 C# 代码展示了如何设置段落的悬挂缩进：");

para2->get_ParagraphFormat()->set_MarginLeft(10.f);
para3->get_ParagraphFormat()->set_MarginLeft(20.f);

auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **管理段落的结束段落运行属性**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 通过其位置获取包含段落的幻灯片的引用。
1. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
1. 向矩形添加一个 [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 包含两个段落。
1. 为段落设置 `FontHeight` 和字体类型。
1. 设置段落的结束属性。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码展示了如何设置 PowerPoint 段落的结束属性：

```c++
// 文档目录的路径。
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 添加一个矩形类型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// 向矩形添加 TextFrame
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// 添加第一个段落
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"示例文本");

para1->get_Portions()->Add(port01);

// 添加第二个段落
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"示例文本 2");

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

Aspose.Slides 提供了增强的导入 HTML 文本到段落的支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
4. 添加并访问 `autoshape` [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 
5. 移除 `ITextFrame` 中的默认段落。
6. 在 TextReader 中读取源 HTML 文件。
7. 通过 [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将读取的 HTML 文件内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/)。
9. 保存修改后的演示文稿。

以下 C++ 代码是导入段落中 HTML 文本的实现：

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// 文档目录的路径。
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 添加一个矩形类型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// 重置默认填充颜色
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// 向矩形添加 TextFrame
ashp->AddTextFrame(u" ");

// 访问文本框
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// 获取段落集合
SharedPtr<Aspose::Slides::IParagraphCollection> ParaCollection = txtFrame->get_Paragraphs();

// 清空添加的文本框中的所有段落
ParaCollection->Clear();

// 使用流读取器加载 HTML 文件
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// 从 HTML 流读取器将文本添加到文本框
ParaCollection->AddFromHtml(tr->ReadToEnd());

// 创建段落对象以用于文本框
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// 创建部分对象用于段落
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose 文本");

// 获取部分格式
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// 设置部分的字体
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

## **将段落文本导出到 HTML**

Aspose.Slides 提供了增强的将文本（包含在段落中）导出到 HTML 的支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 通过其索引访问相关幻灯片的引用。
3. 访问包含要导出到 HTML 的文本的形状。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)。
5. 创建一个 `StreamWriter` 实例并添加新的 HTML 文件。
6. 为 StreamWriter 提供起始索引并导出您所需的段落。

以下 C++ 代码展示了如何将 PowerPoint 段落文本导出到 HTML：

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// 文档目录的路径。
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);

// 访问演示文稿的默认第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 期望的索引
int index = 0;

// 访问已添加的形状
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// 提取第一段作为 HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// 通过提供段落起始索引，总段落数将段落数据写入 HTML
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();
```