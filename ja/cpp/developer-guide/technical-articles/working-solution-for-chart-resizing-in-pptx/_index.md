---
title: PPTX のチャートリサイズの実用的解決策
type: docs
weight: 60
url: /ja/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャートリサイズ
- Excel チャート
- OLE オブジェクト
- チャート埋め込み
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して埋め込み Excel OLE オブジェクトで PPTX の予期しないチャートリサイズを修正します。サイズを一貫させるための2つのコード付き手法を学びましょう。"
---

## **背景**

Excel のチャートを Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込むと、最初にアクティブ化した後にスケールが不定になるようにサイズが変更されることが確認されています。この動作により、チャートのアクティベーション前後でプレゼンテーションの見た目に顕著な違いが生じます。Aspose チームは問題を詳細に調査し、解決策を見つけました。本記事では問題の原因と対応策について説明します。

[前の記事](/slides/ja/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)では、Aspose.Cells for C++ を使って Excel チャートを作成し、Aspose.Slides for C++ を使って PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込む方法を解説しました。[オブジェクト プレビューの問題](/slides/ja/cpp/object-preview-issue-when-adding-oleobjectframe/)に対処するため、チャート画像をチャートの OLE オブジェクト フレームに割り当てました。出力されたプレゼンテーションで、チャート画像が表示された OLE オブジェクト フレームをダブルクリックすると Excel チャートがアクティブ化されます。エンドユーザーは基になる Excel ワークブックで任意の変更を行い、アクティブ化されたワークブックの外側をクリックして対応するスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクト フレームのサイズが変わり、リサイズ率は OLE オブジェクト フレームと埋め込まれた Excel ワークブックの元のサイズに依存します。

## **リサイズの原因**

Excel ワークブックは独自のウィンドウサイズを持っているため、最初のアクティベーション時に元のサイズを保持しようとします。一方、OLE オブジェクト フレームにも独自のサイズがあります。Microsoft によると、Excel ワークブックがアクティブ化されると、Excel と PowerPoint がサイズを調整し、埋め込みプロセスの一部として正しい比率を保ちます。Excel ウィンドウサイズと OLE オブジェクト フレームのサイズまたは位置の違いに応じて、リサイズが発生します。

## **実装可能な解決策**

Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションを作成するシナリオは主に 2 つあります。

**シナリオ 1:** 既存のテンプレートを基にプレゼンテーションを作成する。

**シナリオ 2:** ゼロからプレゼンテーションを作成する。

ここで示す解決策は両シナリオに適用できます。すべてのアプローチの基本は同じです：**埋め込まれた OLE オブジェクトのウィンドウサイズを PowerPoint スライド上の OLE オブジェクト フレームと一致させる**ことです。以下で 2 つのアプローチを説明します。

## **アプローチ 1**

このアプローチでは、埋め込まれた Excel ワークブックのウィンドウサイズを PowerPoint スライド上の OLE オブジェクト フレームのサイズに合わせる方法を学びます。

**シナリオ 1**

テンプレートが定義済みで、テンプレートに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス 2 にあるシェイプに埋め込み Excel ワークブックを含む OLE フレームを配置したいと想定します。このシナリオでは、OLE オブジェクト フレームのサイズは事前に決まっており、インデックス 2 のシェイプのサイズと一致します。やるべきことは、ワークブックのウィンドウサイズをそのシェイプのサイズと同じに設定することです。以下のコードスニペットがその例です。
```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// ウィンドウを使用してチャートのサイズを設定します。
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Set the window width of the workbook in inches (divided by 72 as PowerPoint uses 72 pixels per inch).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Set the window height of the workbook in inches.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Save the workbook to a memory stream.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Create an OLE object frame with the embedded Excel data.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```


**シナリオ 2**

ゼロからプレゼンテーションを作成し、任意のサイズの OLE オブジェクト フレームに埋め込み Excel ワークブックを配置したいとします。以下のコードスニペットでは、スライド上の x = 0.5 インチ、y = 1 インチの位置に高さ 4 インチ、幅 9.5 インチの OLE オブジェクト フレームを作成し、Excel ワークブックのウィンドウも同じサイズ（高さ 4 インチ、幅 9.5 インチ）に設定します。
```cpp
// 目的の高さ。
int32_t desiredHeight = 288; // 4 インチ (4 * 72)

// 目的の幅。
int32_t desiredWidth = 684; // 9.5 インチ (9.5 * 72)

// ウィンドウでチャートサイズを定義する。 
chart->SetSizeWithWindow(true);

// ワークブックのウィンドウ幅をインチ単位で設定する。
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// ワークブックのウィンドウ高さをインチ単位で設定する。
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// ワークブックをメモリストリームに保存する。
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Create an OLE object frame with the embedded Excel data.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## **アプローチ 2**

このアプローチでは、埋め込まれた Excel ワークブック内のチャートサイズを PowerPoint スライド上の OLE オブジェクト フレームのサイズに合わせる方法を学びます。この方法は、チャートサイズが事前に分かっていて変更されない場合に有効です。

**シナリオ 1**

テンプレートが定義済みで、テンプレートに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス 2 にあるシェイプに埋め込み Excel ワークブックを含む OLE フレームを配置したいと想定します。このシナリオでは、OLE フレームのサイズは事前に決まっており、インデックス 2 のシェイプのサイズと一致します。やるべきことは、ワークブック内のチャートサイズをそのシェイプのサイズと同じに設定することです。以下のコードスニペットがその例です。
```cpp
// ウィンドウなしでチャートサイズを定義します。 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// ピクセル単位でチャート幅を設定します（Excel は 1 インチあたり 96 ピクセルを使用するため、96 倍します）。    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// ピクセル単位でチャート高さを設定します。
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// チャートの印刷サイズを定義します。
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// ワークブックをメモリストリームに保存します。
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 埋め込まれた Excel データで OLE オブジェクトフレームを作成します。
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```


**シナリオ 2**

ゼロからプレゼンテーションを作成し、任意のサイズの OLE オブジェクト フレームに埋め込み Excel ワークブックを配置したいとします。以下のコードスニペットでは、スライド上の x = 0.5 インチ、y = 1 インチの位置に高さ 4 インチ、幅 9.5 インチの OLE オブジェクト フレームを作成し、対応するチャートサイズも同じ寸法（高さ 4 インチ、幅 9.5 インチ）に設定します。
```cpp
// 目的の高さ。
int32_t desiredHeight = 288; // 4 インチ (4 * 576)

// 目的の幅。
int32_t desiredWidth = 684; // 9.5 インチ(9.5 * 576)

// ウィンドウなしでチャートサイズを定義します。 
chart->SetSizeWithWindow(false);

// ピクセル単位でチャート幅を設定します。    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// ピクセル単位でチャート高さを設定します。
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// ワークブックをメモリストリームに保存します。
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 埋め込まれた Excel データで OLE オブジェクトフレームを作成します。
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## **結論**

チャートのリサイズ問題を修正する方法は 2 つあります。どちらのアプローチを選択するかは要件とユースケースに依存します。テンプレートから作成する場合でもゼロから作成する場合でも、両アプローチは同様に機能します。また、このソリューションでは OLE オブジェクト フレームのサイズに上限はありません。

## **FAQ**

**埋め込んだ Excel チャートが PowerPoint でアクティブ化後にサイズが変わるのはなぜですか？**

Excel が最初にアクティブ化されたときに元のウィンドウサイズを復元しようとするのに対し、PowerPoint の OLE オブジェクト フレームは独自の寸法を持っているためです。PowerPoint と Excel がサイズを交渉し、アスペクト比を保つ過程でリサイズが発生します。

**このリサイズ問題を完全に防ぐことはできますか？**

はい。埋め込む前に Excel ワークブックのウィンドウサイズまたはチャートサイズを OLE オブジェクト フレームのサイズと一致させれば、チャートサイズの一貫性を保つことができます。

**ウィンドウサイズを合わせる方法とチャートサイズを合わせる方法、どちらを選べばよいですか？**

- ワークブックのアスペクト比を維持したい、または後からサイズ変更の余地を残したい場合は **アプローチ 1（ウィンドウサイズ）** を使用してください。  
- チャートの寸法が固定で埋め込み後に変更しない場合は **アプローチ 2（チャートサイズ）** を使用してください。

**これらの方法はテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？**

はい。両アプローチはテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。

**OLE オブジェクト フレームのサイズに制限はありますか？**

いいえ。OLE フレームはワークブックまたはチャートのサイズに合わせて適切にスケーリングできる限り、任意のサイズに設定できます。

**他のスプレッドシートプログラムで作成したチャートにもこの方法は使えますか？**

例は Aspose.Cells で作成した Excel チャートを対象としていますが、同様のサイズ設定オプションをサポートする OLE 互換のスプレッドシートプログラムであれば、原則は適用できます。

## **関連セクション**

- [Excel チャートを作成し、OLE オブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)