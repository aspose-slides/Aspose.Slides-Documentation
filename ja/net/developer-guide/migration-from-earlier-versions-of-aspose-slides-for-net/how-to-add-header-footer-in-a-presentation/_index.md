---
title: ".NET でプレゼンテーションにヘッダーとフッターを追加する方法"
linktitle: "ヘッダーとフッターの追加"
type: docs
weight: 20
url: /ja/net/how-to-add-header-footer-in-a-presentation/
keywords:
- 移行
- ヘッダーの追加
- フッターの追加
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "レガシーとモダンの Aspose.Slides API の両方を使用して、.NET で PowerPoint PPT、PPTX、ODP プレゼンテーションにヘッダーとフッターを追加する方法を学びます。"
---

{{% alert color="primary" %}} 

新しい [Aspose.Slides for .NET API](/slides/ja/net/) がリリースされ、この単一製品は新規に PowerPoint ドキュメントを生成し、既存のものを編集する機能をサポートします。

{{% /alert %}} 
## **レガシーコードのサポート**
Aspose.Slides for .NET の 13.x 以前のバージョンで開発されたレガシーコードを使用するには、コードにいくつかの小さな変更を加える必要がありますが、変更後も従来どおりに動作します。旧バージョンの Aspose.Slides for .NET で Aspose.Slide および Aspose.Slides.Pptx 名前空間に存在したすべてのクラスは、現在は単一の Aspose.Slides 名前空間に統合されています。レガシー Aspose.Slides API でプレゼンテーションにヘッダー・フッターを追加する以下の簡単なコードスニペットをご覧いただき、新しい統合 API への移行手順をご確認ください。

## **レガシー Aspose.Slides for .NET のアプローチ**
```c#
PresentationEx sourcePres = new PresentationEx();

//ヘッダーとフッターの表示プロパティを設定
sourcePres.UpdateSlideNumberFields = true;

//日時フィールドを更新
sourcePres.UpdateDateTimeFields = true;

//日時プレースホルダーを表示
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//フッタープレースホルダーを表示
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//スライド番号を表示
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//タイトルスライドのヘッダーとフッターの表示を設定
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//プレゼンテーションを書き込む
sourcePres.Write("NewSource.pptx");
```

```c#
//プレゼンテーションを作成
Presentation pres = new Presentation();

//最初のスライドを取得
Slide sld = pres.GetSlideByPosition(1);

//スライドのヘッダー/フッターにアクセス
HeaderFooter hf = sld.HeaderFooter;

//ページ番号の表示を設定
hf.PageNumberVisible = true;

//フッターの表示を設定
hf.FooterVisible = true;

//ヘッダーの表示を設定
hf.HeaderVisible = true;

//日時の表示を設定
hf.DateTimeVisible = true;

//日時の形式を設定
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//ヘッダー文字列を設定
hf.HeaderText = "Header Text";

//フッター文字列を設定
hf.FooterText = "Footer Text";

//プレゼンテーションを書き込む
pres.Write("HeadFoot.ppt");
```


## **新しい Aspose.Slides for .NET 13.x のアプローチ**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //ヘッダー/フッターの表示プロパティを設定
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //日時フィールドを更新
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //日時プレースホルダーを表示
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //フッタープレースホルダーを表示
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //タイトルスライドのヘッダー/フッターの表示を設定
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //プレゼンテーションを書き込む
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
