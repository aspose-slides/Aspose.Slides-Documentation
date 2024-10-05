---
title: プレゼンテーションビューア
type: docs
weight: 50
url: /cpp/presentation-viewer/
keywords:
- PowerPointプレゼンテーションを表示
- pptを表示
- PPTXを表示
- C++
- Aspose.Slides for C++
description: "C++でPowerPointプレゼンテーションを表示"
---

## **スライドからSVG画像を生成する**
Aspose.Slides for C++は、スライドを含むプレゼンテーションファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPointを使用してプレゼンテーションを開くことで表示できます。しかし、場合によっては、開発者が好きな画像ビューアでスライドをSVG画像として表示する必要があるかもしれません。そのような場合、Aspose.Slides for C++では、個々のスライドをSVG画像にエクスポートできます。この記事では、この機能の使用方法を説明します。Aspose.Slides.Pptx for C++を使用して任意のスライドからSVG画像を生成するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
- IDまたはインデックスを使用して、目的のスライドの参照を取得します。
- メモリストリーム内にSVG画像を取得します。
- メモリストリームをファイルに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSlidesSVGImage-CreateSlidesSVGImage.cpp" >}}

## **カスタム形状IDでSVGを生成する**
現在、Aspose.Slides for C++は、カスタム形状IDを持つスライドからSVGを生成するために使用できます。これらのスライドは、Microsoft PowerPointを使用してプレゼンテーションを開くことで表示できます。しかし、場合によっては、開発者が好きな画像ビューアでスライドをSVG画像として表示する必要があるかもしれません。そのような場合、Aspose.Slides for C++では、個々のスライドをSVG画像にエクスポートできます。その目的のために、生成されたSVG内の形状のカスタムIDをサポートするためにISvgShapeにIDプロパティが追加されました。この機能を実装するために、形状IDを設定するために使用できるCustomSvgShapeFormattingControllerが導入されました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GeneratingSVGWithCustomShapeIDS-GeneratingSVGWithCustomShapeIDS.cpp" >}}

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomSvgShapeFormattingController-CustomSvgShapeFormattingController.cpp" >}}

## **スライドサムネイル画像を作成する**
Aspose.Slides for C++は、スライドを含むプレゼンテーションファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPointを使用してプレゼンテーションファイルを開くことで表示できます。しかし、場合によっては、開発者が好きな画像ビューアでスライドを画像として表示する必要があるかもしれません。そのような場合、Aspose.Slides for C++は、スライドのサムネイル画像を生成するのに役立ちます。Aspose.Slides for C++を使用して任意のスライドのサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、任意のスライドの参照を取得します。
1. 指定されたスケールで参照スライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```cpp
// Presentationクラスのインスタンスを作成
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlide.pptx");

// 最初のスライドにアクセス
auto slide = presentation->get_Slide(0);

// フルスケール画像を作成
auto image = slide->GetImage(1, 1);
image->Save(u"Thumbnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **ユーザー定義の寸法でサムネイルを作成する**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、任意のスライドの参照を取得します。
1. 指定されたスケールで参照スライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```cpp
// Presentationクラスのインスタンスを作成
auto presentation = MakeObject<Presentation>(u"ThumbnailWithUserDefinedDimensions.pptx");

// 最初のスライドにアクセス
auto slide = presentation->get_Slide(0);

// ユーザー定義の寸法
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// XおよびYのスケール値を取得
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// カスタムスケール画像を作成
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Thumbnail2_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **ノートスライドビューでスライドからサムネイルを作成する**
Aspose.Slides for C++を使用してノートスライドビューで任意のスライドのサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、任意のスライドの参照を取得します。
1. ノートスライドビューで指定されたスケールで参照スライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

以下のコードスニペットは、ノートスライドビューでプレゼンテーションの最初のスライドのサムネイルを生成します。

```cpp
// Presentationクラスのインスタンスを作成
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlideInNotes.pptx");

// 最初のスライドにアクセス
auto slide = presentation->get_Slide(0);

// ユーザー定義の寸法
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// XおよびYのスケール値を取得
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// フルスケール画像を作成
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Notes_tnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```