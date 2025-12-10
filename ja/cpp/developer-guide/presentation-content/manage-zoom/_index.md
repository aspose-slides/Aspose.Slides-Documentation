---
title: C++ でプレゼンテーションズームを管理
linktitle: ズームの管理
type: docs
weight: 60
url: /ja/cpp/manage-zoom/
keywords:
- ズーム
- ズームフレーム
- スライドズーム
- セクションズーム
- サマリーズーム
- ズームの追加
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してズームを作成およびカスタマイズします — セクション間をジャンプし、PPT、PPTX、ODP プレゼンテーション全体でサムネイルやトランジションを追加します。"
---

## **概要**
PowerPoint のズーム機能を使用すると、プレゼンテーション内の特定のスライド、セクション、または部分へジャンプしたり、そこから戻ったりできます。プレゼンテーション中にコンテンツをすばやくナビゲートできるこの機能は非常に便利です。

![overview_image](Overview.png)

* プレゼンテーション全体を 1 枚のスライドにまとめるには、[サマリーズーム](#Summary-Zoom) を使用します。
* 選択したスライドのみを表示するには、[スライドズーム](#Slide-Zoom) を使用します。
* 単一のセクションのみを表示するには、[セクションズーム](#Section-Zoom) を使用します。

## **スライドズーム**
スライドズームを使用すると、プレゼンテーションをよりダイナミックにし、任意の順序でスライド間を自由に移動でき、プレゼンテーションの流れを中断することなく操作できます。スライドズームはセクションが少ない短いプレゼンテーションに最適ですが、さまざまなシナリオでも利用できます。

スライドズームは、単一のキャンバス上にいるような感覚で複数の情報にドリルダウンできます。

![overview_image](slidezoomsel.png)

スライドズームオブジェクトについては、Aspose.Slides が [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2) 列挙体、[IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame) インターフェイス、および [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) インターフェイス下のいくつかのメソッドを提供します。

### **ズームフレームの作成**
スライドにズームフレームを追加する手順:

1.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2.	ズームフレームをリンクする対象となる新しいスライドを作成します。 
3.	作成したスライドに識別テキストと背景を追加します。
4.	作成したスライドへの参照を含むズームフレームを最初のスライドに追加します。
5.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C++ コードは、スライドにズームフレームを作成する方法を示しています:
``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adds new slides to the presentation
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Creates a background for the second slide
SetSlideBackground(slide2, Color::get_Cyan());

// Creates a text box for the second slide
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Creates a background for the third slide
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Create a text box for the third slide
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adds ZoomFrame objects
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Saves the presentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **カスタム画像付きズームフレームの作成**
Aspose.Slides for C++ を使用して、異なるスライドプレビュー画像を持つズームフレームを作成する手順:

1.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2.	ズームフレームをリンクする対象となる新しいスライドを作成します。 
3.	スライドに識別テキストと背景を追加します。
4.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームを埋めるための [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。
5.	作成したスライドへの参照を含むズームフレームを最初のスライドに追加します。
6.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C++ コードは、異なる画像を使用したズームフレームの作成方法を示しています:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

//2枚目のスライドの背景を作成
SetSlideBackground(slide, Color::get_Cyan());

//3枚目のスライド用テキストボックスを作成
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//ズームオブジェクト用の新しい画像を作成
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//ZoomFrameオブジェクトを追加
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

//プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **ズームフレームの書式設定**
前述のセクションではシンプルなズームフレームの作成方法を示しました。より複雑なズームフレームを作成するには、シンプルなフレームの書式を変更する必要があります。ズームフレームに適用できる書式オプションはいくつかあります。

スライド上でズームフレームの書式を制御する手順:

1.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2.	ズームフレームをリンクする対象となる新しいスライドを作成します。 
3.	作成したスライドに識別テキストと背景を追加します。
4.	作成したスライドへの参照を含むズームフレームを最初のスライドに追加します。
5.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームを埋めるための [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。
6.	最初のズームフレームオブジェクトにカスタム画像を設定します。
7.	2 番目のズームフレームオブジェクトの線の書式を変更します。
8.	2 番目のズームフレームオブジェクトの画像から背景を除去します。
5.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C++ コードは、スライド上でズームフレームの書式を変更する方法を示しています: 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//プレゼンテーションに新しいスライドを追加
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// 2枚目のスライドの背景を作成
SetSlideBackground(slide2, Color::get_Cyan());

// 2枚目のスライド用テキストボックスを作成
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// 3枚目のスライドの背景を作成
SetSlideBackground(slide3, Color::get_DarkKhaki());

// 3枚目のスライド用テキストボックスを作成
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//ZoomFrameオブジェクトを追加
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// ズームオブジェクト用の新しい画像を作成
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
 // ズームフレーム1オブジェクトにカスタム画像を設定
zoomFrame1->set_Image(image);

// ズームフレーム2オブジェクトのフォーマットを設定
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// ズームフレーム2オブジェクトの背景非表示設定
zoomFrame2->set_ShowBackground(false);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **セクションズーム**

セクションズームは、プレゼンテーション内の特定のセクションへのリンクです。強調したいセクションに戻るために使用したり、プレゼンテーションの各部分がどのようにつながっているかを示すために使用したりできます。

![overview_image](seczoomsel.png)

セクションズームオブジェクトについては、Aspose.Slides が [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) インターフェイスと [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) インターフェイス下のいくつかのメソッドを提供します。

### **セクションズームフレームの作成**
スライドにセクションズームフレームを追加する手順:

1.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。 
3.	作成したスライドに識別用の背景を追加します。
4.	ズームフレームをリンクする対象となる新しいセクションを作成します。 
5.	作成したセクションへの参照を含むセクションズームフレームを最初のスライドに追加します。
6.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C++ コードは、スライドにズームフレームを作成する方法を示しています:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// プレゼンテーションに新しいセクションを追加
pres->get_Sections()->AddSection(u"Section 1", slide);

// SectionZoomFrame オブジェクトを追加
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **カスタム画像付きセクションズームフレームの作成**

Aspose.Slides for C++ を使用して、異なるスライドプレビュー画像を持つセクションズームフレームを作成する手順:

1.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用の背景を追加します。
4.	ズームフレームをリンクする対象となる新しいセクションを作成します。 
5.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームを埋めるための [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。
5.	作成したセクションへの参照を含むセクションズームフレームを最初のスライドに追加します。
6.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C++ コードは、異なる画像を使用したセクションズームフレームの作成方法を示しています:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 新しいセクションをプレゼンテーションに追加
pres->get_Sections()->AddSection(u"Section 1", slide);

// ズームオブジェクト用の新しい画像を作成
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// SectionZoomFrame オブジェクトを追加
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **セクションズームフレームの書式設定**

より複雑なセクションズームフレームを作成するには、シンプルなフレームの書式を変更する必要があります。セクションズームフレームに適用できる書式オプションはいくつかあります。

スライド上でセクションズームフレームの書式を制御する手順:

1.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用の背景を追加します。
4.	ズームフレームをリンクする対象となる新しいセクションを作成します。 
5.	作成したセクションへの参照を含むセクションズームフレームを最初のスライドに追加します。
6.	作成したセクションズームオブジェクトのサイズと位置を変更します。
7.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームを埋めるための [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドに戻る* 機能を設定します。 
10.	セクションズームフレームオブジェクトの画像から背景を除去します。
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。
12.	トランジションの継続時間を変更します。
13.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C++ コードは、セクションズームフレームの書式を変更する方法を示しています:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// プレゼンテーションに新しいセクションを追加
pres->get_Sections()->AddSection(u"Section 1", slide);

// SectionZoomFrame オブジェクトを追加
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// SectionZoomFrame の書式設定
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **サマリーズーム**

サマリーズームは、プレゼンテーションの全体像を一度に表示するランディングページのようなものです。プレゼンテーション中に、任意の順序でスライド間を移動したり、スキップしたり、再訪したりでき、プレゼンテーションの流れを中断せずにクリエイティブに操作できます。

![overview_image](sumzoomsel.png)

サマリーズームオブジェクトについては、Aspose.Slides が [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame)、[ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section)、および [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) インターフェイス下のいくつかのメソッドを提供します。

### **サマリーズームの作成**
スライドにサマリーズームフレームを追加する手順:

1.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2.	識別用背景と新しいセクションを持つ新規スライドを作成します。
3.	サマリーズームフレームを最初のスライドに追加します。
4.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C++ コードは、スライドにサマリーズームフレームを作成する方法を示しています:
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// プレゼンテーションに新しいセクションを追加
pres->get_Sections()->AddSection(u"Section 1", slide);

// プレゼンテーションに新しいスライドを追加
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// プレゼンテーションに新しいセクションを追加
pres->get_Sections()->AddSection(u"Section 2", slide);

// プレゼンテーションに新しいスライドを追加
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// プレゼンテーションに新しいセクションを追加
pres->get_Sections()->AddSection(u"Section 3", slide);

// プレゼンテーションに新しいスライドを追加
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// プレゼンテーションに新しいセクションを追加
pres->get_Sections()->AddSection(u"Section 4", slide);

// SummaryZoomFrame オブジェクトを追加
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **サマリーズームセクションの追加と削除**

サマリーズームフレーム内のすべてのセクションは [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section) オブジェクトで表され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) オブジェクトに格納されます。セクションの追加や削除は、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) インターフェイスを通じて次のように行えます:

1.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2.	識別用背景と新しいセクションを持つ新規スライドを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	プレゼンテーションに新しいスライドとセクションを追加します。
5.	作成したセクションをサマリーズームフレームに追加します。
6.	サマリーズームフレームから最初のセクションを削除します。
7.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C++ コードは、サマリーズームフレーム内のセクションの追加と削除方法を示しています:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// プレゼンテーションに新しいセクションを追加
pres->get_Sections()->AddSection(u"Section 1", slide);

//Adds a new slide to the presentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Adds a new section to the presentation
pres->get_Sections()->AddSection(u"Section 2", slide);

// Adds SummaryZoomFrame object
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Adds a new slide to the presentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Adds a new section to the presentation
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Adds a section to the Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Removes section from the Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Saves the presentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **サマリーズームセクションの書式設定**

より複雑なサマリーズームセクションオブジェクトを作成するには、シンプルなフレームの書式を変更する必要があります。サマリーズームセクションオブジェクトに適用できる書式オプションはいくつかあります。

サマリーズームフレーム内のサマリーズームセクションオブジェクトの書式を制御する手順:

1.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2.	識別用背景と新しいセクションを持つ新規スライドを作成します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	`ISummaryZoomSectionCollection` から最初のオブジェクトのサマリーズームセクションを取得します。
7.	[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) オブジェクトに関連付けられた images コレクションに画像を追加して、フレームを埋めるための [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) オブジェクトを作成します。
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドに戻る* 機能を設定します。 
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。
12.	トランジションの継続時間を変更します。
13.	変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

この C++ コードは、サマリーズームセクションオブジェクトの書式を変更する方法を示しています:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// プレゼンテーションに新しいセクションを追加
pres->get_Sections()->AddSection(u"Section 1", slide);

//プレゼンテーションに新しいスライドを追加
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// プレゼンテーションに新しいセクションを追加
pres->get_Sections()->AddSection(u"Section 2", slide);

// SummaryZoomFrame オブジェクトを追加
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// 最初の SummaryZoomSection オブジェクトを取得
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// SummaryZoomSection オブジェクトの書式設定
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

Yes. The [Zoom frame](https://reference.aspose.com/slides/cpp/aspose.slides/zoomframe/) or [section](https://reference.aspose.com/slides/cpp/aspose.slides/sectionzoomframe/) has a `set_ReturnToParent` method that sends viewers back to the originating slide after they visit the target content.

**Can I adjust the 'speed' or duration of the Zoom transition?**

Yes. Zoom supports setting a transition duration so you can control how long the jump animation takes.

**Are there limits on how many Zoom objects a presentation can contain?**

There is no hard API limit documented. Practical limits depend on overall presentation complexity and the viewer's performance. You can add many Zoom frames, but consider file size and rendering time.