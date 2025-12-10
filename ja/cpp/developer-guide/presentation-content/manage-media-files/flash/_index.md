---
title: C++でプレゼンテーションからFlashオブジェクトを抽出
linktitle: Flash
type: docs
weight: 10
url: /ja/cpp/flash/
keywords:
- Flash抽出
- Flashオブジェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用した C++ での PowerPoint および OpenDocument スライドから Flash オブジェクトを抽出する方法を学び、完全なコードサンプルとベストプラクティスを提供します。"
---

## **プレゼンテーションからFlashオブジェクトを抽出**
Aspose.Slides for C++ は、プレゼンテーションからFlashオブジェクトを抽出する機能を提供します。名前でFlashコントロールにアクセスし、プレゼンテーションから抽出してSWFオブジェクトデータを保存できます。
``` cpp
auto pres = System::MakeObject<Presentation>(u"withFlash.pptm");
auto controls = pres->get_Slides()->idx_get(0)->get_Controls();
System::SharedPtr<Control> flashControl;
for (const auto& control : controls)
{
    if (control->get_Name() == u"ShockwaveFlash1")
    {
        flashControl = System::ExplicitCast<Control>(control);
    }
}
```


## **FAQ**

**Flashコンテンツを抽出する際にサポートされているプレゼンテーション形式は何ですか？**

[Aspose.Slides はサポートしています](/slides/ja/cpp/supported-file-formats/) PPTやPPTXなどの主要なPowerPoint形式を。これらのコンテナをロードし、Flash関連のActiveX要素を含むコントロールにアクセスできるためです。

**Flashを含むプレゼンテーションをHTML5に変換し、Flashのインタラクティブ性を保持できますか？**

いいえ。Aspose.Slides はSWFコンテンツを実行したり、そのインタラクティブ性を変換したりしません。[HTML](/slides/ja/cpp/convert-powerpoint-to-html/)/[HTML5](/slides/ja/cpp/export-to-html5/) へのエクスポートはサポートされていますが、サポート終了によりモダンブラウザーでFlashは再生されません。推奨される方法は、エクスポート前にFlashを動画やHTML5アニメーションなどの代替手段に置き換えることです。

**セキュリティ上の観点から、Aspose.Slides はプレゼンテーションを読み込む際にSWFファイルを実行しますか？**

いいえ。Aspose.Slides はFlashをファイルに埋め込まれたバイナリデータとして扱い、処理中にSWFコンテンツを実行しません。

**OLE を使用して埋め込まれた他のファイルと一緒にFlashが含まれるプレゼンテーションはどのように処理すべきですか？**

Aspose.Slides は[埋め込みOLEオブジェクトの抽出](/slides/ja/cpp/manage-ole/)をサポートしているため、Flashコントロールと他のOLE埋め込みドキュメントを一括で処理し、関連するすべての埋め込みコンテンツを一度に扱うことができます。