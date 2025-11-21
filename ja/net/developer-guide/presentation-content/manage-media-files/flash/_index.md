---
title: ".NET でプレゼンテーションから Flash オブジェクトを抽出"
linktitle: "Flash"
type: docs
weight: 10
url: /ja/net/flash/
keywords:
- "Flash を抽出"
- "Flash オブジェクト"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides を使用して .NET で PowerPoint および OpenDocument スライドから Flash オブジェクトを抽出する方法、完全な C# コードサンプルとベストプラクティスを学びます。"
---

## **プレゼンテーションからFlashオブジェクトを抽出**
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


## **FAQ**

**Flashコンテンツを抽出する際にサポートされているプレゼンテーション形式は何ですか？**

[Aspose.Slides はサポートしています](/slides/ja/net/supported-file-formats/) 主要なPowerPoint形式（PPTやPPTX）をサポートします。これらのコンテナを読み込み、Flash関連のActiveX要素を含むコントロールにアクセスできるためです。

**Flash を含むプレゼンテーションを HTML5 に変換し、Flash のインタラクティブ性を保持できますか？**

いいえ。Aspose.Slides はSWFコンテンツを実行せず、インタラクティブ性も変換しません。[HTML](/slides/ja/net/convert-powerpoint-to-html/)/[HTML5](/slides/ja/net/export-to-html5/) へのエクスポートはサポートされていますが、サポート終了によりモダンブラウザでFlashは再生されません。推奨される方法は、エクスポート前にFlashをビデオやHTML5アニメーションなどの代替手段に置き換えることです。

**セキュリティの観点から、Aspose.Slides はプレゼンテーションの読み取り中に SWF ファイルを実行しますか？**

いいえ。Aspose.Slides はFlashをファイルに埋め込まれたバイナリデータとして扱い、処理中にSWFコンテンツを実行しません。

**Flash と他の埋め込みファイルが OLE で含まれているプレゼンテーションはどのように扱うべきですか？**

[埋め込みOLEオブジェクトの抽出](/slides/ja/net/manage-ole/) をサポートしているため、1 回の処理で関連するすべての埋め込みコンテンツを処理でき、Flash コントロールと他の OLE 埋め込みドキュメントを一緒に扱うことができます。