---
title: 在 C++ 中管理 PowerPoint 文字段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- 新增文字
- 新增段落
- 管理文字
- 管理段落
- 管理項目符號
- 段落縮排
- 懸掛縮排
- 段落項目符號
- 編號清單
- 項目符號清單
- 段落屬性
- 匯入 HTML
- 文字轉 HTML
- 段落轉 HTML
- 段落轉影像
- 文字轉影像
- 匯出段落
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 完善段落格式——在 PPT、PPTX 與 ODP 簡報中優化對齊、間距與樣式。"
---
## **簡介**

Aspose.Slides 提供您在 C++ 中處理 PowerPoint 文字、段落與段落內部部分所需的所有介面與類別。

* Aspose.Slides 提供 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 介面，讓您可以新增代表段落的物件。`ITextFame` 物件可以包含一個或多個段落（每個段落透過換行字元建立）。
* Aspose.Slides 提供 [IParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/) 介面，讓您可以新增代表文字部分的物件。`IParagraph` 物件可以包含一個或多個部分（`iPortions` 物件的集合）。
* Aspose.Slides 提供 [IPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/) 介面，讓您可以新增代表文字及其格式屬性的物件。

`IParagraph` 物件可透過其底層的 `IPortion` 物件處理具不同格式屬性的文字。

## **加入包含多個部分的多段落**

以下步驟示範如何加入一個文字框，其中包含 3 個段落，每個段落各有 3 個部分：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相應投影片的參考。
3. 在投影片上加入矩形 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
4. 取得與該 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 相關聯的 ITextFrame。
5. 建立兩個 [IParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/) 物件，並將它們加入 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 的 `IParagraphs` 集合。
6. 為每個新 `IParagraph` 建立三個 [IPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/) 物件（預設段落只有兩個 Portion 物件），並將每個 `IPortion` 物件加入相應 `IParagraph` 的 IPortion 集合。
7. 為每個部分設定文字。
8. 使用 `IPortion` 物件所公開的格式屬性，套用您偏好的格式設定。
9. 儲存已修改的投影片。

以下 C++ 程式碼實作上述加入包含部分的段落步驟：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 存取第一張投影片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 新增矩形類型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// 在矩形上新增 TextFrame
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// 存取第一個段落
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// 新增第二個段落
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// 新增第三個段落
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

// 將 PPTX 儲存至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **管理段落項目符號**

項目符號列表能快速有效地組織與呈現資訊。使用項目符號的段落較易閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相應投影片的參考。
3. 在選取的投影片上加入 [autoshape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
4. 取得該 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 將段落的項目符號 `Type` 設為 `Symbol`，並設定項目符號字元。
8. 設定段落的 `Text`。
9. 設定段落的 `Indent` 以調整項目符號縮排。
10. 設定項目符號的顏色。
11. 設定項目符號的高度。
12. 將新段落加入 `TextFrame` 的段落集合。
13. 加入第二個段落，並重複第 7 步至第 13 步的流程。
14. 儲存投影片。

以下 C++ 程式碼示範如何加入段落項目符號：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 新增矩形類型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// 在矩形上新增 TextFrame
ashp->AddTextFrame(u"");

// 取得文字框
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// 為文字框建立 Paragraph 物件
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//設定文字
paragraph->set_Text(u"Welcome to Aspose.Slides");

// 設定項目符號縮排
paragraph->get_ParagraphFormat()->set_Indent (25);

// 設定項目符號顏色
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
    
// 設定 IsBulletHardColor 為 true 以使用自訂項目符號顏色
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
                                                                                
// 設定項目符號高度
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// 將段落加入文字框
txtFrame->get_Paragraphs()->Add(paragraph);

// 建立第二個段落
// 為文字框建立 Paragraph 物件
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//設定文字
paragraph2->set_Text(u"This is numbered bullet");

// 設定段落項目符號類型與樣式
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// 設定項目符號縮排
paragraph2->get_ParagraphFormat()->set_Indent(25);

// 設定項目符號顏色
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// 設定 IsBulletHardColor 為 true 以使用自訂項目符號顏色
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// 設定項目符號高度
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// 將段落加入文字框
txtFrame->get_Paragraphs()->Add(paragraph2);


// 儲存 PPTX 至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **管理圖片項目符號**

項目符號列表能快速有效地組織與呈現資訊。圖片段落易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相應投影片的參考。
3. 在投影片上加入 [autoshape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
4. 取得該 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 透過 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 載入圖片。
8. 將項目符號類型設定為 [Picture](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/)，並設定圖片。
9. 設定段落的 `Text`。
10. 設定段落的 `Indent` 以調整項目符號縮排。
11. 設定項目符號的顏色。
12. 設定項目符號的高度。
13. 將新段落加入 `TextFrame` 的段落集合。
14. 加入第二個段落，並依前述步驟重複。
15. 儲存已修改的投影片。

以下 C++ 程式碼示範如何新增與管理圖片項目符號：

```c++
// 建立代表 PPTX 檔案的 Presentation 類別實例
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// 取得第一張投影片
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 建立項目符號用的影像實例
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// 新增並存取 AutoShape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 取得 AutoShape 的 TextFrame
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// 移除預設段落
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// 建立新段落
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// 設定段落項目符號樣式與影像
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// 設定項目符號高度
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// 將段落加入文字框
paragraphs->Add(paragraph);

// 將簡報寫入為 PPTX 檔案
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// 將簡報寫入為 PPT 檔案
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **管理多層級項目符號**

項目符號列表能快速有效地組織與呈現資訊。多層級項目符號易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相應投影片的參考。
3. 在新投影片上加入 [autoshape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
4. 取得該 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraph/) 類別建立第一個段落實例，並將深度設定為 0。
7. 使用 `Paragraph` 類別建立第二個段落實例，並將深度設定為 1。
8. 使用 `Paragraph` 類別建立第三個段落實例，並將深度設定為 2。
9. 使用 `Paragraph` 類別建立第四個段落實例，並將深度設定為 3。
10. 將新段落加入 `TextFrame` 的段落集合。
11. 儲存已修改的投影片。

以下 C++ 程式碼示範如何新增與管理多層級項目符號：

```c++
// 建立代表 PPTX 檔案的 Presentation 類別實例
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// 取得第一張投影片
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// 新增並存取 AutoShape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 取得已建立 AutoShape 的文字框
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// 清除預設段落
text->get_Paragraphs()->Clear();

// 新增第一個段落
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 設定項目符號層級
para1Format->set_Depth(0);

// 新增第二個段落
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 設定項目符號層級
para2Format->set_Depth(1);

// 新增第三個段落
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 設定項目符號層級
para3Format->set_Depth(2);

// 新增第四個段落
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// 設定項目符號層級
para4Format->set_Depth(3);

// 新增段落至集合
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// 將簡報寫入為 PPTX 檔案
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **管理使用自訂編號列表的段落**

[IBulletFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/) 介面提供 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 屬性等，可讓您管理使用自訂編號或格式的段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 取得包含段落的投影片。
3. 在投影片上加入 [autoshape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
4. 取得該 autoshape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraph/) 類別建立第一個段落實例，並將 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 設為 2。
7. 使用 `Paragraph` 類別建立第二個段落實例，並將 `NumberedBulletStartWith` 設為 3。
8. 使用 `Paragraph` 類別建立第三個段落實例，並將 `NumberedBulletStartWith` 設為 7。
9. 將新段落加入 `TextFrame` 的段落集合。
10. 儲存已修改的投影片。

以下 C++ 程式碼示範如何新增與管理使用自訂編號或格式的段落：

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// 取得已建立 AutoShape 的文字框
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// 移除預設的現有段落
textFrame->get_Paragraphs()->RemoveAt(0);

// 第一個清單
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

## **設定段落的首行縮排**

使用 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_indent/) 方法可控制段落的首行縮排。此方法僅會移動相對於段落左邊界的第一行。正值會將第一行向右移動，其他行則保持與段落本體對齊。

當需要移動整個段落時，請使用 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_marginleft/)。僅需移動首行時，請使用 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_indent/)。

以下範例建立多個段落，並套用不同的 `Indent` 值，以示範首行縮排如何影響段落版面。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上加入矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/autoshape/)。
4. 在圖形中加入空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textframe/)，並移除預設段落。
5. 建立多個段落，並為它們設定不同的 [Indent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_indent/) 值。
6. 將段落加入文字框。
7. 儲存已修改的投影片。

以下程式碼示範如何設定段落縮排：

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

結果：

![The first-line indent of the paragraphs](first_line_indent.png)

## **設定段落的懸掛縮排**

懸掛縮排是一種段落版面配置，第一行位於其餘行的左側。於 Aspose.Slides 中，可使用 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_indent/) 方法達成。將縮排設定為負值，即可使第一行相對於段落本體向左移動。

實務上，`IParagraphFormat::set_MarginLeft` 定義段落本體的左側位置，`IParagraphFormat::set_Indent` 定義第一行相對於該左側位置的偏移。若要產生懸掛縮排，請將正的 `MarginLeft` 與負的 `Indent` 同時設定。

此格式常用於書目、參考文獻、詞彙表條目，以及其他需要將換行後的行對齊於段落本體而非第一行首字的段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上加入矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/autoshape/)。
4. 在圖形中加入空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textframe/)，並移除預設段落。
5. 為每個段落建立段落，並設定正的 [MarginLeft](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_marginleft/) 值。
6. 設定負的 [Indent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_indent/) 值，以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的投影片。

以下程式碼示範如何為段落設定懸掛縮排：

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

結果：

![The hanging indent of the paragraphs](hanging_indent.png)

## **管理段落結尾執行屬性**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 取得包含段落之投影片的參考（依其位置）。
1. 在投影片上加入矩形 [autoshape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
1. 在矩形中加入含有兩個段落的 [TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。
1. 為段落設定 `FontHeight` 與字型。
1. 設定段落的 End 屬性。
1. 將已修改的投影片寫出為 PPTX 檔案。

以下 C++ 程式碼示範如何為段落設定 End 屬性：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 存取第一張投影片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 新增矩形類型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// 在矩形上新增 TextFrame
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// 新增第一個段落
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// 新增第二個段落
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// 將 PPTX 儲存至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **將 HTML 文字匯入段落**

Aspose.Slides 提供加強的 HTML 文字匯入段落支援。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相應投影片的參考。
3. 在投影片上加入 [autoshape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
4. 加入並取得 `autoshape` 的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。
5. 移除 `ITextFrame` 中的預設段落。
6. 在 TextReader 中讀取來源 HTML 檔案。
7. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraph/) 類別建立第一個段落實例。
8. 將讀取的 TextReader 內容加入 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraphcollection/)。
9. 儲存已修改的投影片。

以下 C++ 程式碼實作匯入 HTML 文字至段落的步驟：

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// 文件目錄的路徑。
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 新增矩形類型的 AutoShape
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// 重設預設填色
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// 在矩形上新增 TextFrame
ashp->AddTextFrame(u" ");

// 取得文字框
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// 取得 Paragraphs 集合
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// 清除已新增文字框中的所有段落
ParaCollection->Clear();

// 使用 StreamReader 載入 HTML 檔案
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// 將 HTML StreamReader 的文字加入文字框
ParaCollection->AddFromHtml(tr->ReadToEnd());

// 建立文字框的 Paragraph 物件
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// 為段落建立 Portion 物件
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// 取得 Portion 格式
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// 設定 Portion 的字型
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// 設定字型的粗體屬性
pf->set_FontBold(NullableBool::True);

// 設定字型的斜體屬性
pf->set_FontItalic(NullableBool::True);

// 設定字型的底線屬性
pf->set_FontUnderline(TextUnderlineType::Single);

// 設定字型的高度
pf->set_FontHeight(25);

// 設定字型的顏色
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// 將 PPTX 儲存至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **將段落文字匯出為 HTML**

Aspose.Slides 提供加強的將段落文字匯出為 HTML 的支援。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例並載入目標投影片。
2. 透過索引取得相應投影片的參考。
3. 取得包含欲匯出為 HTML 之文字的圖形。
4. 取得圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。
5. 建立 `StreamWriter` 實例並新增 HTML 檔案。
6. 為 `StreamWriter` 提供起始索引，匯出您偏好的段落。

以下 C++ 程式碼示範如何將 PowerPoint 段落文字匯出為 HTML：

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// 文件目錄的路徑。
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// 存取簡報的預設第一張投影片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 目標索引
int index = 0;

// 取得已加入的圖形
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// 將第一段落匯出為 HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// 透過提供段落起始索引與要複製的段落總數，將段落資料寫入 HTML
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **將段落儲存為影像**

本節將示範兩個範例，說明如何將以 [IParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/) 介面表示的文字段落儲存為影像。兩個範例皆會透過 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 介面的 `GetImage` 方法取得包含段落的圖形影像，計算段落在圖形中的界限，並將其匯出為位圖影像。這些方法讓您能從 PowerPoint 投影片中擷取特定文字區段並儲存為獨立影像，適用於各種後續使用情境。

假設我們有一個名為 sample.pptx 的投影片檔，內含一張投影片，第一個圖形為包含三個段落的文字方塊。

![The text box with three paragraphs](paragraph_to_image_input.png)

**範例 1**

在此範例中，我們取得第二段落的影像。為此，我們先從第一張投影片的圖形取得影像，然後計算文字框中第二段落的界限。接著將段落重新繪製到新的位圖影像，並以 PNG 格式儲存。此方法特別適用於需要將特定段落以獨立影像保存，同時保留文字的精確尺寸與格式。

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// 將圖形儲存在記憶體中作為位圖。
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// 從記憶體建立圖形位圖。
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// 計算第二段落的邊界。
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// 計算輸出影像的尺寸（最小尺寸為 1x1 像素）。
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// 為段落準備位圖。
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// 從圖形位圖重新繪製段落到段落位圖。
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

結果：

![The paragraph image](paragraph_to_image_output.png)

**範例 2**

在此範例中，我們在先前的做法加入了縮放因子。從投影片中提取的圖形以 `2` 的縮放因子儲存為影像，允許更高解析度的輸出。段落界限亦會考慮縮放比例。縮放在需要更高細節的影像時特別有用，例如用於高品質印刷材料。

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// 將圖形以縮放方式儲存在記憶體中作為位圖。
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

## **常見問題集**

**我可以完全停用文字框內的換行嗎？**

是的。使用文字框的換行方法 ([set_WrapText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textframeformat/set_wraptext/)) 即可關閉換行，使行不會在框線邊緣斷開。

**如何取得特定段落在投影片上的精確範圍？**

您可以取得段落（甚至單一 Portion）的邊界矩形，以了解其在投影片上的精確位置與大小。

**段落的對齊方式（左/右/置中/兩端對齊）在哪裡控制？**

[Alignment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraphformat/set_alignment/) 是 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraphformat/) 的段落層級設定；它會套用於整個段落，而不會影響單獨的 Portion 格式。

**我可以為段落中的某一段文字（例如某個字）設定拼寫檢查語言嗎？**

是的。語言會在 Portion 層級使用 [PortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_languageid/) 設定，因而可以在同一段落內共存多種語言。