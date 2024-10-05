---
title: プレゼンテーションにヘッダーとフッターを追加する方法
type: docs
weight: 20
url: /net/how-to-add-header-footer-in-a-presentation/
---

{{% alert color="primary" %}} 

新しい[Aspose.Slides for .NET API](/slides/net/)がリリースされ、これ一つの製品でゼロからPowerPointドキュメントを生成し、既存のものを編集する機能をサポートしています。

{{% /alert %}} 
## **レガシーコードのサポート**
Aspose.Slides for .NETの13.x以前のバージョンで開発されたレガシーコードを使用するには、いくつかの小さな変更を加える必要があります。そうすれば、従来通りに動作します。古いAspose.Slides for .NETでAspose.SlideおよびAspose.Slides.Pptx名前空間に存在したすべてのクラスは、現在単一のAspose.Slides名前空間に統合されました。以下の簡単なコードスニペットをご覧いただき、レガシーAspose.Slides APIでプレゼンテーションにヘッダーとフッターを追加する方法を確認し、新しい統合APIへの移行手順に従ってください。
## **レガシーAspose.Slides for .NETアプローチ**
```c#
PresentationEx sourcePres = new PresentationEx();

//ヘッダー・フッターの可視性プロパティを設定
sourcePres.UpdateSlideNumberFields = true;

//日付時刻フィールドを更新
sourcePres.UpdateDateTimeFields = true;

//日付時刻のプレースホルダーを表示
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//フッターのプレースホルダーを表示
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//スライド番号を表示
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//タイトルスライドでのヘッダー・フッターの可視性を設定
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//プレゼンテーションをディスクに書き込む
sourcePres.Write("NewSource.pptx");
```

```c#
//プレゼンテーションを作成
Presentation pres = new Presentation();

//最初のスライドを取得
Slide sld = pres.GetSlideByPosition(1);

//スライドのヘッダー / フッターにアクセス
HeaderFooter hf = sld.HeaderFooter;

//ページ番号の可視性を設定
hf.PageNumberVisible = true;

//フッターの可視性を設定
hf.FooterVisible = true;

//ヘッダーの可視性を設定
hf.HeaderVisible = true;

//日付時刻の可視性を設定
hf.DateTimeVisible = true;

//日付時刻のフォーマットを設定
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//ヘッダーテキストを設定
hf.HeaderText = "ヘッダーテキスト";

//フッターテキストを設定
hf.FooterText = "フッターテキスト";

//プレゼンテーションをディスクに書き込む
pres.Write("HeadFoot.ppt");
```



## **新しいAspose.Slides for .NET 13.xアプローチ**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //ヘッダー・フッターの可視性プロパティを設定
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //日付時刻フィールドを更新
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //日付時刻のプレースホルダーを表示
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //フッターのプレースホルダーを表示
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //タイトルスライドでのヘッダー・フッターの可視性を設定
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //プレゼンテーションをディスクに書き込む
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```