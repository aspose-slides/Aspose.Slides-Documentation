---
title: .NET でプレゼンテーションにヘッダーとフッターを追加する方法
linktitle: ヘッダーとフッターの追加
type: docs
weight: 20
url: /ja/net/how-to-add-header-footer-in-a-presentation/
keywords:
- 移行
- ヘッダー追加
- フッター追加
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
description: "レガシーとモダンの両方の Aspose.Slides API を使用して、.NET で PowerPoint PPT、PPTX、ODP プレゼンテーションにヘッダーとフッターを追加する方法を学びます。"
---
{{% alert color="info" %}} 
新しい[Aspose.Slides for .NET API](/slides/ja/net/)がリリースされ、この単一製品は、ゼロからPowerPointドキュメントを生成し、既存のものを編集する機能をサポートしています。
{{% /alert %}} 
## **レガシーコードのサポート**
13.x以前のAspose.Slides for .NETバージョンで開発されたレガシーコードを使用するには、コードにいくつかの小さな変更を加える必要がありますが、コードは以前と同様に動作します。旧Aspose.Slides for .NETのAspose.SlideおよびAspose.Slides.Pptx名前空間に存在していたすべてのクラスは、現在単一のAspose.Slides名前空間に統合されています。レガシーAspose.Slides APIでプレゼンテーションにヘッダーとフッターを追加する以下のシンプルなコードスニペットをご覧いただき、新しい統合APIへの移行手順をご確認ください。
## **レガシー Aspose.Slides for .NET アプローチ**
```c#
PresentationEx sourcePres = new PresentationEx();

//ヘッダーとフッターの表示プロパティを設定
sourcePres.UpdateSlideNumberFields = true;

//日付時刻フィールドを更新
sourcePres.UpdateDateTimeFields = true;

//日付時刻プレースホルダーを表示
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//フッタープレースホルダーを表示
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//スライド番号を表示
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//タイトルスライドでヘッダーとフッターの表示を設定
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//プレゼンテーションを書き込む
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

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

//日付時刻の表示を設定
hf.DateTimeVisible = true;

//日付時刻の形式を設定
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//ヘッダーテキストを設定
hf.HeaderText = "Header Text";

//フッターテキストを設定
hf.FooterText = "Footer Text";

//プレゼンテーションを書き込み
pres.Write("HeadFoot.ppt");
```

## **新しい Aspose.Slides for .NET 13.x アプローチ**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //ヘッダーとフッターの表示プロパティを設定
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //日付時刻フィールドを更新
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //日付時刻プレースホルダーを表示
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //フッタープレースホルダーを表示
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //タイトルスライドでヘッダーとフッターの表示を設定
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //プレゼンテーションを書き込む
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```