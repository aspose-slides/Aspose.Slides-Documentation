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
description: ".NET で PowerPoint PPT、PPTX、ODP プレゼンテーションにヘッダーとフッターを追加する方法を、レガシーおよびモダンな Aspose.Slides API を使用して学びます。"
---

{{% alert color="primary" %}} 
新しい [Aspose.Slides for .NET API](/slides/ja/net/) がリリースされ、この単一製品で、PowerPoint ドキュメントをゼロから生成したり、既存のドキュメントを編集したりする機能がサポートされています。
{{% /alert %}} 
## **レガシーコードのサポート**
13.x より前の Aspose.Slides for .NET バージョンで開発されたレガシーコードを使用するには、コードにいくつかの小さな変更を加える必要がありますが、変更後も従来通りに動作します。旧 Aspose.Slides for .NET の Aspose.Slide および Aspose.Slides.Pptx 名前空間に存在していたすべてのクラスは、現在単一の Aspose.Slides 名前空間に統合されています。以下のシンプルなコードスニペット（レガシー Aspose.Slides API でプレゼンテーションにヘッダーとフッターを追加する例）をご覧いただき、新しい統合 API への移行手順をご確認ください。
## **レガシー Aspose.Slides for .NET アプローチ**
```c#
PresentationEx sourcePres = new PresentationEx();

//Setting Header Footer visibility properties
sourcePres.UpdateSlideNumberFields = true;

//Update the Date Time Fields
sourcePres.UpdateDateTimeFields = true;

//Show date time placeholder
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Show the footer place holder
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Show Slide Number
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Set the  header footer visibility on Title Slide
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Write the presentation to the disk
sourcePres.Write("NewSource.pptx");
```

```c#
//プレゼンテーションを作成する
Presentation pres = new Presentation();

//最初のスライドを取得する
Slide sld = pres.GetSlideByPosition(1);

//スライドのヘッダー/フッターにアクセスする
HeaderFooter hf = sld.HeaderFooter;

//ページ番号の表示を設定する
hf.PageNumberVisible = true;

//フッターの表示を設定する
hf.FooterVisible = true;

//ヘッダーの表示を設定する
hf.HeaderVisible = true;

//日時の表示を設定する
hf.DateTimeVisible = true;

//日時の形式を設定する
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//ヘッダーテキストを設定する
hf.HeaderText = "Header Text";

//フッターテキストを設定する
hf.FooterText = "Footer Text";

//プレゼンテーションを書き込む
pres.Write("HeadFoot.ppt");
```


## **新しい Aspose.Slides for .NET 13.x アプローチ**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //ヘッダー/フッターの表示プロパティを設定する
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //日付時刻フィールドを更新する
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //日付時刻プレースホルダーを表示する
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //フッタープレースホルダーを表示する
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //タイトルスライドでヘッダーとフッターの表示を設定する
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //プレゼンテーションをディスクに書き込む
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
