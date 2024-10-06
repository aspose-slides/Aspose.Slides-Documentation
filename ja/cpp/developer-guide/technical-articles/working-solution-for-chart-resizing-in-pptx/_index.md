---
title: PPTXにおけるチャートのリサイズのための作業ソリューション
type: docs
weight: 60
url: /ja/cpp/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Asposeコンポーネントを介してPowerPointプレゼンテーションにOLEとして埋め込まれたExcelチャートが、初回アクティベーション後に未特定のスケールにリサイズされることが観察されています。この動作は、チャートのアクティベーション前後でプレゼンテーションにかなりの視覚的差を生み出します。AsposeチームはMicrosoftチームの助けを借りて、この問題を詳細に調査し、その解決策を見つけました。本記事では、この問題の理由と解決策について説明します。

{{% /alert %}} 
## **背景**
[前回の記事](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) では、Aspose.Cells for C++を使用してExcelチャートを作成し、そのチャートをAspose.Slides for C++を使用してPowerPointプレゼンテーションに埋め込む方法を説明しました。オブジェクトが変更された問題に対処するために、チャート画像をチャートOLEオブジェクトフレームに割り当てました。出力プレゼンテーションでは、チャート画像を表示しているOLEオブジェクトフレームをダブルクリックすると、Excelチャートがアクティベートされます。エンドユーザーは、実際のExcelワークブックで任意の変更を行い、アクティベートされたExcelワークブックの外をクリックすることで、関連するスライドに戻ることができます。ユーザーがスライドに戻ると、OLEオブジェクトフレームのサイズが変更されます。リサイズファクターは、OLEオブジェクトフレームのサイズや埋め込まれたExcelワークブックによって異なります。

## **リサイズの原因**
Excelワークブックには独自のウィンドウサイズがあるため、初回のアクティベーション時にその元のサイズを保持しようとします。一方、OLEオブジェクトフレームには独自のサイズがあります。Microsoftによれば、Excelワークブックがアクティベートされると、ExcelとPowerPointはサイズを交渉し、埋め込み操作の一環として正しい比率であることを確認します。ExcelウィンドウのサイズとOLEオブジェクトフレームのサイズ/位置の違いに基づいて、リサイズが行われます。

## **作業ソリューション**
Aspose.Slides for C++を使用してPowerPointプレゼンテーションを作成するための2つの可能なシナリオがあります。

**シナリオ1:** 既存のテンプレートに基づいてプレゼンテーションを作成します。

**シナリオ2:** ゼロからプレゼンテーションを作成します。

ここで提供する解決策は、両方のシナリオに対して有効です。すべての解決策アプローチの基本は同じです。それは、**埋め込まれたOLEオブジェクトウィンドウのサイズは、PowerPointスライドのOLEオブジェクトフレームのサイズと同じであるべきである**ということです。では、解決策の2つのアプローチについて説明します。

## **最初のアプローチ**
このアプローチでは、埋め込まれたExcelワークブックのウィンドウサイズをPowerPointスライドのOLEオブジェクトフレームのサイズに等しく設定する方法を学びます。

**シナリオ1** 

テンプレートを定義し、このテンプレートに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス2にある形状にOLEフレームを配置する想定です。このシナリオでは、OLEオブジェクトフレームのサイズは予め定義されていると見なされます（これはテンプレートのインデックス2にある形状のサイズです）。私たちが行うべきことは、ワークブックのウィンドウサイズを形状のサイズと等しく設定することです。次のコードスニペットがこの目的に役立ちます:

``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
// ウィンドウと連動したチャートサイズを定義
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shapes()->idx_get(2);

// ウィンドウの幅をインチ単位で設定（PowerPointは
// 1インチあたり72ピクセルを使用するため、72で割る）
wb->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// ウィンドウの高さをインチ単位で設定
wb->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// メモリストリームをインスタンス化
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream3(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// 埋め込まれたExcelを持つOLEオブジェクトフレームを作成
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(), 
	shape->get_Height(),
	dataInfo);
```

**シナリオ2** 

ゼロからプレゼンテーションを作成したいとし、任意のサイズのOLEオブジェクトフレームを持つ埋め込まれたExcelワークブックが必要とします。次のコードスニペットでは、スライド内に4インチの高さと9.5インチの幅を持つOLEオブジェクトフレームを作成し、x軸=0.5インチ、y軸=1インチに配置します。さらに、同等のExcelワークブックのウィンドウサイズ、つまり、高さ4インチ、幅9.5インチを設定しました。

``` cpp
// 私たちの望む高さ
int32_t desiredHeight = 288; // 4インチ (4 * 72)

// 私たちの望む幅
int32_t desiredWidth = 684; // 9.5インチ (9.5 * 72)

// ウィンドウと連動したチャートサイズを定義
chart->SetSizeWithWindow(true);

// ウィンドウの幅をインチ単位で設定
wb->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// ウィンドウの高さをインチ単位で設定
wb->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// メモリストリームをインスタンス化
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// 埋め込まれたExcelを持つOLEオブジェクトフレームを作成
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f,
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```


## **第二のアプローチ**
このアプローチでは、埋め込まれたExcelワークブック内に存在するチャートのサイズをPowerPointスライドのOLEオブジェクトフレームのサイズに等しく設定する方法を学びます。このアプローチは、チャートのサイズが事前に知られており、変更されることがない場合に有用です。

**シナリオ1** 

テンプレートを定義し、このテンプレートに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス2にある形状にOLEフレームを配置する想定です。このシナリオでは、OLEフレームのサイズは予め定義されていると見なされます（これはテンプレートのインデックス2にある形状のサイズです）。私たちが行うべきことは、ワークブック内のチャートのサイズを形状のサイズと等しく設定することです。次のコードスニペットがこの目的に役立ちます:

``` cpp
// ウィンドウなしのチャートサイズを定義
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shapes()->idx_get(2);

// ピクセル単位でチャートの幅を設定（Excelは1インチあたり96ピクセルを使用するため、96で乗算）
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// ピクセル単位でチャートの高さを設定
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// チャート印刷サイズを定義
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// メモリストリームをインスタンス化
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// 埋め込まれたExcelを持つOLEオブジェクトフレームを作成
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(),
	shape->get_Height(),
	dataInfo);
```

**シナリオ2** 

ゼロからプレゼンテーションを作成したいとし、任意のサイズのOLEオブジェクトフレームを持つ埋め込まれたExcelワークブックが必要とします。次のコードスニペットでは、スライド内に4インチの高さと9.5インチの幅を持つOLEオブジェクトフレームを作成し、x軸=0.5インチ、y軸=1インチに配置します。さらに、同等のチャートサイズ、つまり高4インチ、幅9.5インチを設定しました。

``` cpp
// 私たちの望む高さ
int32_t desiredHeight = 288; // 4インチ (4 * 576)

// 私たちの望む幅
int32_t desiredWidth = 684; // 9.5インチ(9.5 * 576)

// ウィンドウなしのチャートサイズを定義
chart->SetSizeWithWindow(false);

// ピクセル単位でチャートの幅を設定    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// ピクセル単位でチャートの高さを設定    
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// メモリストリームをインスタンス化
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// 埋め込まれたExcelを持つOLEオブジェクトフレームを作成
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f, 
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```

## **結論**
{{% alert color="primary" %}} 

チャートのリサイズの問題を修正するための2つのアプローチがあります。適切なアプローチの選択は、要件と使用ケースに依存します。どちらのアプローチも、テンプレートから作成されたプレゼンテーションでもゼロから作成されたプレゼンテーションでも同じ方法で機能します。また、解決策においてOLEオブジェクトフレームのサイズに制限はありません。

{{% /alert %}} 
## **関連セクション**
[プレゼンテーションにExcelチャートをOLEオブジェクトとして作成し埋め込む](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)