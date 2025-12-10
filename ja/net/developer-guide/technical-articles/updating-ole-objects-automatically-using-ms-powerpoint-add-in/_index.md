---
title: PowerPoint アドインを使用した OLE オブジェクトの自動更新
type: docs
weight: 10
url: /ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE オブジェクト
- OLE の更新
- 自動的に
- アドイン
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPoint のアドインと Aspose.Slides for .NET を使用して OLE チャートやオブジェクトを自動的に更新する方法を解説します。実用的なコードと最適化のヒントも掲載しています。"
---

## **OLE オブジェクトを自動的に更新する**

Aspose.Slides for .NET のお客様から最も頻繁に寄せられる質問のひとつは、編集可能なチャート（またはその他の OLE オブジェクト）を作成または変更し、プレゼンテーションを開いたときに自動的に更新されるようにする方法です。残念ながら、PowerPoint は Excel や Word と同様に自動マクロをサポートしていません。利用できるマクロは `Auto_Open` と `Auto_Close` だけで、これらはアドインからのみ自動的に実行されます。この短いテクニカルチップでは、その実現方法を示します。

まず、PowerPoint に Auto_Open マクロ機能を追加する無料アドインがいくつか提供されています。例として [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) と [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html) があります。

これらのアドインのいずれかをインストールしたら、以下のようにテンプレートプレゼンテーションに `Auto_Open()` マクロ（Event Generator を使用している場合は `OnPresentationOpen()`）を追加するだけです:
```cs
public void Auto_Open()
{
    // プレゼンテーション内の各スライドをループします。
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // 現在のスライド上のすべてのシェイプをループします。
        foreach (var oShape in oSlide.Shapes)
        {
            // シェイプが OLE オブジェクトかどうかをチェックします。
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // OLE オブジェクトが見つかりました。そのオブジェクト参照を取得し、更新します。
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // 現在、OLE サーバープログラムを終了します。
                // メモリが解放され、問題が防止されます。
                // また、oObject を Nothing に設定してオブジェクトを解放します。
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```


Aspose.Slides for .NET で OLE オブジェクトに加えた変更は、PowerPoint がプレゼンテーションを開く際に自動的に更新されます。多数の OLE オブジェクトがありすべてを更新したくない場合は、処理対象のシェイプにカスタムタグを付け、マクロ内でそのタグをチェックするだけです。