---
title: ズームの管理
type: docs
weight: 60
url: /ja/cpp/manage-zoom/
keywords: "ズーム, ズームフレーム, ズームを追加, ズームフレームのフォーマット, サマリーズーム, PowerPointプレゼンテーション, C++, Aspose.Slides for C++"
description: "C++でPowerPointプレゼンテーションにズームまたはズームフレームを追加する"
---

## **概要**
PowerPointのズームを使用すると、特定のスライド、セクション、およびプレゼンテーションの部分にジャンプしたり、戻ったりできます。この機能は、プレゼンテーション中にコンテンツを迅速にナビゲートするのに非常に役立つ場合があります。

![overview_image](Overview.png)

* プレゼンテーション全体を1つのスライドに要約するには、[サマリーズーム](#Summary-Zoom)を使用します。
* 選択したスライドだけを表示するには、[スライドズーム](#Slide-Zoom)を使用します。
* 単一のセクションのみを表示するには、[セクションズーム](#Section-Zoom)を使用します。

## **スライドズーム**
スライドズームを使用すると、プレゼンテーションの流れを中断せずに、選択した順序でスライド間を自由に移動できるようになります。スライドズームはセクションが少ない短いプレゼンテーションに最適ですが、さまざまなプレゼンテーションシナリオで使用することもできます。

スライドズームでは、単一のキャンバスにいるように感じながら、複数の情報を掘り下げるのに役立ちます。

![overview_image](slidezoomsel.png)

スライドズームオブジェクトには、Aspose.Slidesは[ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2)列挙型、[IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame)インターフェイス、および[IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection)インターフェイスの下にいくつかのメソッドを提供します。

### **ズームフレームの作成**

この方法でスライドにズームフレームを追加できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. ズームフレームにリンクさせる新しいスライドを作成します。
3. 作成したスライドに識別テキストと背景を追加します。
4. 最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC++コードは、スライドにズームフレームを作成する方法を示しています：

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

//プレゼンテーションに新しいスライドを追加
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// 2番目のスライドに背景を作成
SetSlideBackground(slide2, Color::get_Cyan());

// 2番目のスライドのテキストボックスを作成
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// 3番目のスライドに背景を作成
SetSlideBackground(slide3, Color::get_DarkKhaki());

// 3番目のスライドのテキストボックスを作成
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//ズームフレームオブジェクトを追加
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **カスタム画像を使ったズームフレームの作成**
Aspose.Slides for C++を使って、次の方法で異なるスライドプレビュー画像を持つズームフレームを作成できます：
1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. ズームフレームにリンクさせる新しいスライドを作成します。
3. スライドに識別テキストと背景を追加します。
4. 画像を[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)オブジェクトに関連付けられたImagesコレクションに追加して、フレームを埋めるために使用される[IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)オブジェクトを作成します。
5. 最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
6. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC++コードは、異なる画像を使用してズームフレームを作成する方法を示しています：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// 2番目のスライドに背景を作成
SetSlideBackground(slide, Color::get_Cyan());

// 3番目のスライドのテキストボックスを作成
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// ズームオブジェクト用の新しい画像を作成
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//ズームフレームオブジェクトを追加
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **ズームフレームのフォーマット**
前のセクションでは、シンプルなズームフレームの作成方法を示しました。より複雑なズームフレームを作成するには、シンプルなフレームのフォーマットを変更する必要があります。ズームフレームに適用できるフォーマットオプションはいくつかあります。

スライド上でズームフレームのフォーマットを制御する方法は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. ズームフレームにリンクさせる新しいスライドを作成します。
3. 作成したスライドに識別テキストと背景を追加します。
4. 最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)オブジェクトに関連付けられたImagesコレクションに画像を追加して、フレームを埋めるために使用される[IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)オブジェクトを作成します。
6. 最初のズームフレームオブジェクトのカスタム画像を設定します。
7. 2番目のズームフレームオブジェクトのライン形式を変更します。
8. 2番目のズームフレームオブジェクトの画像から背景を削除します。
9. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC++コードは、スライド上でズームフレームのフォーマットを変更する方法を示しています：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//プレゼンテーションに新しいスライドを追加
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// 2番目のスライドに背景を作成
SetSlideBackground(slide2, Color::get_Cyan());

// 2番目のスライドのテキストボックスを作成
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// 3番目のスライドに背景を作成
SetSlideBackground(slide3, Color::get_DarkKhaki());

// 3番目のスライドのテキストボックスを作成
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//ズームフレームオブジェクトを追加
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// ズームオブジェクト用の新しい画像を作成
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// zoomFrame1オブジェクトのカスタム画像を設定
zoomFrame1->set_Image(image);

// zoomFrame2オブジェクトのズームフレームフォーマットを設定
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// zoomFrame2オブジェクトの背景を表示しない設定
zoomFrame2->set_ShowBackground(false);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **セクションズーム**

セクションズームは、プレゼンテーション内のセクションへのリンクです。セクションズームを使用して、強調したいセクションに戻ったり、プレゼンテーションの特定の部分の関連性を強調したりできます。

![overview_image](seczoomsel.png)

セクションズームオブジェクトには、Aspose.Slidesは[ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame)インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection)インターフェイスの下のいくつかのメソッドを提供しています。

### **セクションズームフレームの作成**

この方法でスライドにセクションズームフレームを追加できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. 新しいスライドを作成します。
3. 作成したスライドに識別背景を追加します。
4. ズームフレームをリンクさせたい新しいセクションを作成します。
5. 最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC++コードは、スライドにズームフレームを作成する方法を示しています：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// プレゼンテーションに新しいセクションを追加
pres->get_Sections()->AddSection(u"Section 1", slide);

// SectionZoomFrameオブジェクトを追加
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **カスタム画像を使ったセクションズームフレームの作成**

Aspose.Slides for C++を使用して、次の方法で異なるスライドプレビュー画像を持つセクションズームフレームを作成できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. 新しいスライドを作成します。
3. 作成したスライドに識別背景を追加します。
4. ズームフレームをリンクさせたい新しいセクションを作成します。
5. 画像を[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)オブジェクトに関連付けられたImagesコレクションに追加して、フレームを埋めるために使用される[IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)オブジェクトを作成します。
6. 最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
7. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC++コードは、異なる画像を使用してセクションズームフレームを作成する方法を示しています：

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

// セクションズームフレームオブジェクトを追加
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **セクションズームフレームのフォーマット**

より複雑なセクションズームフレームを作成するには、シンプルなフレームのフォーマットを変更する必要があります。セクションズームフレームに適用できるフォーマットオプションはいくつかあります。

次の方法でスライド上のセクションズームフレームのフォーマットを制御できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. 新しいスライドを作成します。
3. 作成したスライドに識別背景を追加します。
4. ズームフレームをリンクさせたい新しいセクションを作成します。
5. 最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6. 作成したセクションズームオブジェクトのサイズと位置を変更します。
7. 画像を[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)オブジェクトに関連付けられたImagesコレクションに追加して、フレームを埋めるために使用される[IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)オブジェクトを作成します。
8. 作成したセクションズームフレームオブジェクトのカスタム画像を設定します。
9. リンクされたセクションから元のスライドに戻る機能を設定します。
10. セクションズームフレームオブジェクトの画像から背景を削除します。
11. 2番目のズームフレームオブジェクトのライン形式を変更します。
12. トランジションの持続時間を変更します。
13. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC++コードは、スライド上でセクションズームフレームのフォーマットを変更する方法を示しています：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//プレゼンテーションに新しいスライドを追加
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// プレゼンテーションに新しいセクションを追加
pres->get_Sections()->AddSection(u"Section 1", slide);

// セクションズームフレームオブジェクトを追加
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// セクションズームフレームのフォーマット
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

サマリーズームは、プレゼンテーションのすべての部分が一度に表示されるランディングページのようなものです。プレゼンテーション中に、ズームを使用して、プレゼンテーションの任意の場所に好きな順序で移動できます。創造的に行動したり、先に進んだり、プレゼンテーションの流れを中断することなくスライドショーの一部に戻ったりできます。

![overview_image](sumzoomsel.png)

サマリーズームオブジェクトには、Aspose.Slidesは[ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame)、[ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section)、および[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection)インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection)インターフェイスの下にいくつかのメソッドを提供しています。

### **サマリーズームの作成**

この方法でスライドにサマリーズームフレームを追加できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. 識別背景を持つ新しいスライドと、作成したスライド用の新しいセクションを作成します。
3. 最初のスライドにサマリーズームフレームを追加します。
4. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC++コードは、スライドにサマリーズームフレームを作成する方法を示しています：

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

// サマリーズームフレームオブジェクトを追加
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **サマリーズームセクションの追加と削除**

サマリーズームフレーム内のすべてのセクションは[ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section)オブジェクトで表され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection)オブジェクトに格納されます。次の方法で[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection)インターフェイスを通じてサマリーズームセクションオブジェクトを追加または削除できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. 識別背景を持つ新しいスライドと、作成したスライド用の新しいセクションを作成します。
3. 最初のスライドにサマリーズームフレームを追加します。
4. 新しいスライドとセクションをプレゼンテーションに追加します。
5. 作成したセクションをサマリーズームフレームに追加します。
6. サマリーズームフレームから最初のセクションを削除します。
7. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC++コードは、サマリーズームフレーム内のセクションを追加および削除する方法を示しています：

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

// サマリーズームフレームオブジェクトを追加
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//プレゼンテーションに新しいスライドを追加
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// プレゼンテーションに新しいセクションを追加
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// サマリーズームにセクションを追加
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// サマリーズームからセクションを削除
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// プレゼンテーションを保存
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **サマリーズームセクションのフォーマット**

より複雑なサマリーズームセクションオブジェクトを作成するには、シンプルなフレームのフォーマットを変更する必要があります。サマリーズームセクションオブジェクトに適用できるフォーマットオプションはいくつかあります。

次の方法でサマリーズームフレーム内のサマリーズームセクションオブジェクトのフォーマットを制御できます：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. 識別背景を持つ新しいスライドと、作成したスライド用の新しいセクションを作成します。
3. 最初のスライドにサマリーズームフレームを追加します。
4. `ISummaryZoomSectionCollection`から最初のオブジェクトを取得します。
5. 画像を[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)オブジェクトに関連付けられた画像コレクションに追加して、フレームを埋めるために使用される[IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)オブジェクトを作成します。
6. 作成したセクションズームフレームオブジェクトのカスタム画像を設定します。
7. リンクされたセクションから元のスライドに戻る機能を設定します。
8. 2番目のズームフレームオブジェクトのライン形式を変更します。
9. トランジションの持続時間を変更します。
10. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC++コードは、サマリーズームセクションオブジェクトのフォーマットを変更する方法を示しています：

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

// サマリーズームフレームオブジェクトを追加
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// 最初のSummaryZoomSectionオブジェクトを取得
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// サマリーズームセクションオブジェクトのフォーマット
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