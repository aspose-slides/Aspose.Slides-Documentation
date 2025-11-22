---
title: フラッシュ
type: docs
weight: 10
url: /ja/net/flash/
keywords: "フラッシュの抽出, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションからフラッシュオブジェクトを抽出する"
---

## **プレゼンテーションからFlashオブジェクトを抽出する**
Aspose.Slides for .NET は、プレゼンテーションからFlashオブジェクトを抽出する機能を提供します。名前でFlashコントロールにアクセスし、プレゼンテーションから抽出してSWFオブジェクトデータを保存することができます。
```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```


## **よくある質問**

**Flashコンテンツを抽出する際にサポートされているプレゼンテーション形式は何ですか？**

[Aspose.Slides supports](/slides/ja/net/supported-file-formats/) は、PPTやPPTXなどの主要なPowerPoint形式をサポートしています。これらのコンテナをロードし、Flash関連のActiveX要素を含むコントロールにアクセスできるためです。

**Flashを含むプレゼンテーションをHTML5に変換し、Flashのインタラクティブ性を保持できますか？**

いいえ。Aspose.Slides はSWFコンテンツを実行したり、そのインタラクティブ性を変換したりしません。エクスポート先として[HTML](/slides/ja/net/convert-powerpoint-to-html/)/[HTML5](/slides/ja/net/export-to-html5/) がサポートされていますが、サポート終了のため、現代のブラウザではFlashは再生できません。推奨される方法は、エクスポート前にFlashをビデオやHTML5アニメーションなどの代替手段に置き換えることです。

**セキュリティ上の観点から、Aspose.Slidesはプレゼンテーションの読み取り中にSWFファイルを実行しますか？**

いいえ。Aspose.Slides はFlashをファイルに埋め込まれたバイナリデータとして扱い、処理中にSWFコンテンツを実行しません。

**OLEを介して埋め込まれた他のファイルとともにFlashを含むプレゼンテーションはどのように扱うべきですか？**

Aspose.Slides は[extracting embedded OLE objects](/slides/ja/net/manage-ole/) をサポートしているため、Flashコントロールと他のOLE埋め込みドキュメントを一度に処理し、関連するすべての埋め込みコンテンツを一括で扱うことができます。