---
title: Python を使用した読み取り専用モードでプレゼンテーションを保存
linktitle: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/python-net/read-only-presentation/
keywords:
- 読み取り専用
- プレゼンテーションの保護
- 編集の防止
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint ファイル（PPT、PPTX）を読み取り専用モードでロードおよび保存し、プレゼンテーションを変更せずに正確なスライドプレビューを提供します。"
---

## **読み取り専用モードの適用**

PowerPoint 2019 で、Microsoft は **常に読み取り専用で開く** 設定を導入しました。これはユーザーがプレゼンテーションを保護するために使用できるオプションのひとつです。次のような状況でこの読み取り専用設定を使用したい場合があります。

- 誤って編集されるのを防ぎ、プレゼンテーションの内容を安全に保ちたいとき。  
- 配布したプレゼンテーションが最終版であることを受取手に知らせたいとき。

プレゼンテーションに **常に読み取り専用で開く** オプションを選択すると、ユーザーがファイルを開いたときに **読み取り専用** の推奨が表示され、次のようなメッセージが出ます。*誤って変更しないように、作者はこのファイルを読み取り専用で開くよう設定しています。*

**読み取り専用** の推奨は、ユーザーが編集を行う前に解除作業が必要になるため、編集を抑止するシンプルながら効果的な手段です。プレゼンテーションの変更を防止し、丁寧にその旨を伝えたい場合、**読み取り専用** の推奨は有効な選択肢となります。

> **Read-Only** の保護が付いたプレゼンテーションが、最近導入された機能に対応していない古いバージョンの Microsoft PowerPoint で開かれた場合、**読み取り専用** の推奨は無視され（プレゼンテーションは通常通り開く）ことがあります。

Aspose.Slides for Python via .NET を使用すると、プレゼンテーションを **読み取り専用** に設定できます。これにより、ユーザーはプレゼンテーションを開いたときに **読み取り専用** の推奨が表示されます。以下のサンプルコードは、Python で Aspose.Slides を使用してプレゼンテーションを **読み取り専用** に設定する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
**注**: **読み取り専用** の推奨は、PowerPoint プレゼンテーションの誤編集や誤変更を防止することを目的とした単なる注意喚起です。意図的に編集を行う知識のある人は、簡単に読み取り専用設定を解除できます。もし本格的に不正な編集を防止したい場合は、[暗号化やパスワードを伴うより厳格な保護](https://docs.aspose.com/slides/python-net/password-protected-presentation/) を使用する方が適しています。 
{{% /alert %}} 

## **FAQ**

**「読み取り専用の推奨」はフルパスワード保護とどう違うのですか？**

「読み取り専用の推奨」は、ファイルを読み取り専用モードで開くよう提案するだけで、簡単に回避できます。[パスワード保護](/slides/ja/python-net/password-protected-presentation/) は、実際に開く・編集することを制限し、真のセキュリティが必要な場合に適しています。

**「読み取り専用の推奨」を透かしと組み合わせて、編集をさらに抑止できますか？**

可能です。推奨メッセージは [透かし](/slides/ja/python-net/watermark/) と組み合わせて視覚的に編集を抑止する手段として機能します。両者は別個の仕組みであり、併用すると効果が高まります。

**推奨が有効な状態でも、マクロや外部ツールでファイルを変更できますか？**

はい。推奨はプログラムによる変更をブロックしません。自動化された編集を防止したい場合は、[パスワードと暗号化](/slides/ja/python-net/password-protected-presentation/) を使用してください。

**「読み取り専用の推奨」は `is_encrypted` や `is_write_protected` フラグとどう関係していますか？**

これらは別のシグナルです。「読み取り専用の推奨」はソフトな任意の提示であり、[is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_write_protected/) や [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_encrypted/) は実際の書き込み・読み取り制限を示します。後者はパスワードや暗号化に依存します。