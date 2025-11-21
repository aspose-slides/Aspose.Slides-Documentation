---
title: Python を使用した読み取り専用モードでのプレゼンテーション保存
linktitle: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/python-net/read-only-presentation/
keywords:
- 読み取り専用
- プレゼンテーションの保護
- 編集防止
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint ファイル（PPT、PPTX）を読み取り専用モードでロードおよび保存し、プレゼンテーションを変更せずに正確なスライド プレビューを提供します。"
---

## **読み取り専用モードを適用**

PowerPoint 2019で、Microsoftはプレゼンテーションを保護するためのオプションの1つとして、**Always Open Read-Only** 設定を導入しました。次の場合に、この読み取り専用設定を使用してプレゼンテーションを保護したくなることがあります。

- 誤って編集されるのを防ぎ、プレゼンテーションの内容を安全に保ちたい場合。
- 提供したプレゼンテーションが最終版であることをユーザーに知らせたい場合。

プレゼンテーションに **Always Open Read-Only** オプションを設定すると、ユーザーがプレゼンテーションを開いたときに **Read-Only** の推奨が表示され、次のようなメッセージが表示されることがあります: *誤って変更されないように、作成者はこのファイルを読み取り専用で開くように設定しました。*

Read-Only の推奨は、編集を抑止するシンプルながら効果的な手段で、ユーザーは編集可能にする前にこの推奨を解除する作業が必要になります。プレゼンテーションへの変更を許可したくなく、丁寧にその旨を伝えたい場合、Read-Only の推奨は有力なオプションとなります。

> **Read-Only** 保護が設定されたプレゼンテーションを、最近導入された機能をサポートしていない古いMicrosoft PowerPointアプリケーションで開くと、**Read-Only** の推奨は無視され（プレゼンテーションは通常通り開かれます）。

Aspose.Slides for Python via .NET を使用すると、プレゼンテーションを **Read-Only** に設定でき、ユーザーは（プレゼンテーションを開いた後） **Read-Only** の推奨を確認できます。以下のサンプルコードは、Aspose.Slides を利用して Python でプレゼンテーションを **Read-Only** に設定する方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 

**注**: **Read-Only** の推奨は、PowerPoint プレゼンテーションの編集を抑止したり、誤って変更されるのを防ぐことを目的としたものです。もし知識のある動機のある人がプレゼンテーションを編集しようとすれば、Read-Only 設定は簡単に解除できます。未承認の編集を確実に防止したい場合は、[暗号化とパスワードを含むより厳格な保護](https://docs.aspose.com/slides/python-net/password-protected-presentation/) を使用する方が適切です。 

{{% /alert %}} 

## **FAQ**

**'Read-Only recommended'はフルパスワード保護と何が違うのですか？**

'Read-Only recommended' はファイルを読み取り専用モードで開くことを提案するだけで、回避が容易です。[Password protection](/slides/ja/python-net/password-protected-presentation/) は実際に開くことや編集を制限し、実際のセキュリティ制御が必要な場合に適しています。

**'Read-Only recommended'を透かしと組み合わせて編集をさらに抑止できますか？**

はい。推奨は[watermarks](/slides/ja/python-net/watermark/) と組み合わせて視覚的な抑止手段とすることができ、これらは別々の仕組みであり、相互に有効に機能します。

**推奨が有効な状態でも、マクロや外部ツールでファイルを変更できますか？**

はい。推奨はプログラムによる変更をブロックしません。自動的な編集を防止するには、[passwords and encryption](/slides/ja/python-net/password-protected-presentation/) を使用してください。

**'Read-Only recommended'はフラグ 'is_encrypted' と 'is_write_protected' とどのように関連していますか？**

これらは異なるシグナルです。'Read-Only recommended' はソフトでオプションのプロンプトであり、[is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_write_protected/) と [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_encrypted/) はパスワードや暗号化に依存した実際の書き込みまたは読み取り制限を示します。