---
title: C++ でプレゼンテーションズームを管理する
linktitle: ズームを管理する
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
description: "Aspose.Slides for C++ を使用してズームを作成およびカスタマイズします — セクション間をジャンプし、サムネイルとトランジションを PPT、PPTX、ODP プレゼンテーション全体に追加します。"
---

## **Overview**
PowerPoint のズーム機能は、プレゼンテーション内の特定のスライド、セクション、領域間を自由にジャンプできるようにします。プレゼンテーション中に、コンテンツを素早くナビゲートできるこの機能は非常に便利です。 

![overview_image](Overview.png)

* プレゼンテーション全体を1枚のスライドで要約するには、[サマリーズーム](#Summary-Zoom) を使用します。
* 選択したスライドのみを表示するには、[スライドズーム](#Slide-Zoom) を使用します。
* 単一のセクションのみを表示するには、[セクションズーム](#Section-Zoom) を使用します。

## **Slide Zoom**
スライドズームを使用すると、プレゼンテーションがよりダイナミックになり、任意の順序でスライド間を自由にナビゲートでき、プレゼンテーションの流れを中断せずに進められます。  
スライドズームは、セクションが少ない短いプレゼンテーションに最適ですが、さまざまなシナリオでも使用できます。  
スライドズームは、あたかも単一のキャンバス上にいるかのように、複数の情報に掘り下げてアクセスできます。  

![overview_image](slidezoomsel.png)

スライドズームオブジェクトに対して、Aspose.Slides は [ZoomImageType](https://reference.aspose.com/slides/cpp/aspose.slides/zoomimagetype/) 列挙体、[IZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/izoomframe/) インターフェイス、および [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) インターフェイス下のいくつかのメソッドを提供します。

### **Create Zoom Frames**
スライドにズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	ズームフレームをリンクする新しいスライドを作成します。  
3.	作成したスライドに識別用テキストと背景を追加します。  
4.	作成したスライドへの参照を含むズームフレームを最初のスライドに追加します。  
5.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この C++ コードは、スライドにズームフレームを作成する方法を示しています。  
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

//プレゼンテーションに新しいスライドを追加する
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// 2番目のスライドの背景を作成する
SetSlideBackground(slide2, Color::get_Cyan());

// 2番目のスライドのテキストボックスを作成する
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// 3番目のスライドの背景を作成する
SetSlideBackground(slide3, Color::get_DarkKhaki());

// 3番目のスライドのテキストボックスを作成する
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//ZoomFrame オブジェクトを追加する
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// プレゼンテーションを保存する
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Create Zoom Frames with Custom Images**
Aspose.Slides for C++ を使用すると、異なるスライドプレビュー画像を持つズームフレームを次の手順で作成できます。 

1.	[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	ズームフレームをリンクする新しいスライドを作成します。  
3.	スライドに識別用テキストと背景を追加します。  
4.	[IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームを埋める画像として使用します。  
5.	作成したスライドへの参照を含むズームフレームを最初のスライドに追加します。  
6.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この C++ コードは、異なる画像を使用したズームフレームの作成方法を示しています。  
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// 2番目のスライドの背景を作成
SetSlideBackground(slide, Color::get_Cyan());

// 3番目のスライドのテキストボックスを作成
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// ズームオブジェクト用の新しい画像を作成
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//ZoomFrame オブジェクトを追加
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Format Zoom Frames**
前のセクションでは、簡単なズームフレームの作成方法を示しました。より複雑なズームフレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。ズームフレームに適用できる書式設定オプションはいくつかあります。  

スライド上でズームフレームの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	ズームフレームをリンクする新しいスライドを作成します。  
3.	作成したスライドに識別用テキストと背景を追加します。  
4.	作成したスライドへの参照を含むズームフレームを最初のスライドに追加します。  
5.	[IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームを埋める画像として使用します。  
6.	最初のズームフレームオブジェクトにカスタム画像を設定します。  
7.	2 番目のズームフレームオブジェクトの線の書式を変更します。  
8.	2 番目のズームフレームオブジェクトの画像から背景を削除します。  
5.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この C++ コードは、スライド上でズームフレームの書式設定を変更する方法を示しています。  
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//プレゼンテーションに新しいスライドを追加
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// 2番目のスライドの背景を作成
SetSlideBackground(slide2, Color::get_Cyan());

// 2番目のスライドのテキストボックスを作成
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// 3番目のスライドの背景を作成
SetSlideBackground(slide3, Color::get_DarkKhaki());

// 3番目のスライドのテキストボックスを作成
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//ZoomFrame オブジェクトを追加
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// ズームオブジェクト用の新しい画像を作成
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// zoomFrame1 オブジェクトにカスタム画像を設定
zoomFrame1->set_Image(image);

// zoomFrame2 オブジェクトのズームフレーム書式を設定
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// zoomFrame2 オブジェクトの背景非表示設定
zoomFrame2->set_ShowBackground(false);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Section Zoom**
セクションズームは、プレゼンテーション内のセクションへのリンクです。セクションズームを使用して、特に強調したいセクションに戻ることができます。また、プレゼンテーションの特定の部分がどのように接続しているかをハイライトすることもできます。  

![overview_image](seczoomsel.png)

セクションズームオブジェクトに対して、Aspose.Slides は [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isectionzoomframe/) インターフェイスおよび [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) インターフェイス下のいくつかのメソッドを提供します。

### **Create Section Zoom Frames**
スライドにセクションズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	新しいスライドを作成します。  
3.	作成したスライドに識別用の背景を追加します。  
4.	ズームフレームをリンクする新しいセクションを作成します。  
5.	作成したセクションへの参照を含むセクションズームフレームを最初のスライドに追加します。  
6.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この C++ コードは、スライドにズームフレームを作成する方法を示しています。  
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 新しいセクションをプレゼンテーションに追加
pres->get_Sections()->AddSection(u"Section 1", slide);

// SectionZoomFrame オブジェクトを追加
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Create Section Zoom Frames with Custom Images**
異なるスライドプレビュー画像を持つセクションズームフレームを次の手順で作成できます。  

1.	[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	新しいスライドを作成します。  
3.	作成したスライドに識別用背景を追加します。  
4.	ズームフレームをリンクする新しいセクションを作成します。  
5.	[IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームを埋める画像として使用します。  
5.	作成したセクションへの参照を含むセクションズームフレームを最初のスライドに追加します。  
6.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この C++ コードは、異なる画像を使用したズームフレームの作成方法を示しています。  
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// プレゼンテーションに新しいセクションを追加
pres->get_Sections()->AddSection(u"Section 1", slide);

// ズームオブジェクト用の新しい画像を作成
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// SectionZoomFrame オブジェクトを追加
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Format Section Zoom Frames**
より複雑なセクションズームフレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。セクションズームフレームに適用できる書式設定オプションはいくつかあります。  

スライド上でセクションズームフレームの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	新しいスライドを作成します。  
3.	作成したスライドに識別用背景を追加します。  
4.	ズームフレームをリンクする新しいセクションを作成します。  
5.	作成したセクションへの参照を含むセクションズームフレームを最初のスライドに追加します。  
6.	作成したセクションズームオブジェクトのサイズと位置を変更します。  
7.	[IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームを埋める画像として使用します。  
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。  
9.	リンクされたセクションから元のスライドに戻る機能を設定します。  
10.	セクションズームフレームオブジェクトの画像から背景を削除します。  
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。  
12.	トランジションの期間を変更します。  
13.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この C++ コードは、セクションズームフレームの書式設定を変更する方法を示しています。  
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// 新しいセクションをプレゼンテーションに追加
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


## **Summary Zoom**
サマリーズームは、プレゼンテーションのすべての要素を一度に表示するランディングページのようなものです。プレゼンテーション中に、任意の順序で任意の場所にジャンプして移動でき、クリエイティブに進めたり、前後に飛んだり、スライドショーの一部に戻ったりして、プレゼンテーションの流れを中断せずに操作できます。  

![overview_image](sumzoomsel.png)

サマリーズームオブジェクトに対して、Aspose.Slides は [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomframe/)、[ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/)、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/) インターフェイスおよび [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) インターフェイス下のいくつかのメソッドを提供します。

### **Create Summary Zoom**
サマリーズームフレームをスライドに追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	識別用背景と新しいセクションを持つ新しいスライドを作成します。  
3.	サマリーズームフレームを最初のスライドに追加します。  
4.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この C++ コードは、スライドにサマリーズームフレームを作成する方法を示しています。  
``` cpp 
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


### **Add and Remove a Summary Zoom Section**
サマリーズームフレーム内のすべてのセクションは [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/) オブジェクトで表され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/) オブジェクトに格納されます。セクションの追加または削除は、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/) インターフェイスを通じて次のように行います。

1.	[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	識別用背景と新しいセクションを持つ新しいスライドを作成します。  
3.	最初のスライドにサマリーズームフレームを追加します。  
4.	プレゼンテーションに新しいスライドとセクションを追加します。  
5.	作成したセクションをサマリーズームフレームに追加します。  
6.	サマリーズームフレームから最初のセクションを削除します。  
7.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この C++ コードは、サマリーズームフレーム内のセクションの追加と削除方法を示しています。  
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

// プレゼンテーションにSummaryZoomFrameオブジェクトを追加
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//プレゼンテーションに新しいスライドを追加
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// プレゼンテーションに新しいセクションを追加
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Summary Zoomにセクションを追加
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Summary Zoomからセクションを削除
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Format Summary Zoom Sections**
より複雑なサマリーズームセクションオブジェクトを作成するには、シンプルなフレームの書式設定を変更する必要があります。サマリーズームセクションオブジェクトに適用できる書式設定オプションはいくつかあります。  

サマリーズームフレーム内のサマリーズームセクションオブジェクトの書式設定を制御する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2.	識別用背景と新しいセクションを持つ新しいスライドを作成します。  
3.	最初のスライドにサマリーズームフレームを追加します。  
4.	`ISummaryZoomSectionCollection` から最初のオブジェクトのサマリーズームセクションを取得します。  
7.	[IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) オブジェクトを作成し、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) オブジェクトに関連付けられた images コレクションに画像を追加して、フレームを埋める画像として使用します。  
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。  
9.	リンクされたセクションから元のスライドに戻る機能を設定します。  
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。  
12.	トランジションの期間を変更します。  
13.	変更したプレゼンテーションを PPTX ファイルとして書き出します。  

この C++ コードは、サマリーズームセクションオブジェクトの書式設定を変更する方法を示しています。  
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// 新しいセクションをプレゼンテーションに追加
pres->get_Sections()->AddSection(u"Section 1", slide);

//プレゼンテーションに新しいスライドを追加
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// 新しいセクションをプレゼンテーションに追加
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

**対象を表示した後に「親」スライドに戻る制御はできますか？**  
はい。[Zoom frame](https://reference.aspose.com/slides/cpp/aspose.slides/zoomframe/) または [section](https://reference.aspose.com/slides/cpp/aspose.slides/sectionzoomframe/) には、対象コンテンツを閲覧した後に元のスライドに戻す `set_ReturnToParent` メソッドがあります。

**ズームのトランジションの「速度」や期間を調整できますか？**  
はい。ズームはトランジション期間を設定できるため、ジャンプ アニメーションの長さを制御できます。

**プレゼンテーションに含められるズームオブジェクトの数に制限はありますか？**  
公式に documented されたハードな API 制限はありません。実際の限界はプレゼンテーション全体の複雑さやビューアのパフォーマンスに依存します。多数のズームフレームを追加できますが、ファイルサイズとレンダリング時間に留意してください。