---
title: Python を使用した読み取り専用モードでプレゼンテーションを保存
linktitle: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/python-java/read-only-presentation/
keywords:
- 読み取り専用
- プレゼンテーション保護
- 編集防止
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint ファイル（PPT、PPTX）を読み取り専用モードで読み込みおよび保存し、プレゼンテーションを変更せずに正確なスライドプレビューを提供します。"
---
## **はじめに**

PowerPoint 2019 で、Microsoft はプレゼンテーションを保護するオプションの一つとして **Always Open Read-Only** 設定を導入しました。次のような場合にこの読み取り専用設定を使用してプレゼンテーションを保護したいことがあります。

- 誤って編集されるのを防ぎ、プレゼンテーションの内容を安全に保ちたいとき。  
- 提供したプレゼンテーションが最終版であることを利用者に知らせたいとき。

プレゼンテーションに **Always Open Read-Only** オプションを選択すると、利用者がファイルを開いた際に **Read-Only** の推奨が表示され、次のようなメッセージが表示されることがあります。*To prevent accidental changes, the author has set this file to open as read-only.*

**Read-Only** の推奨は、編集を抑止するシンプルながら効果的な deterrent であり、利用者は編集可能にするために設定を解除する手順を踏む必要があります。利用者に変更させたくない場合や、丁寧にその旨を伝えたい場合は **Read-Only** の推奨が適したオプションとなります。

> **Read-Only** 保護が付いたプレゼンテーションを、最近の機能をサポートしていない古い Microsoft PowerPoint アプリケーションで開くと、**Read-Only** の推奨は無視され（プレゼンテーションは通常通り開く）ます。

## **読み取り専用モードの適用**

Aspose.Slides for Python via Java を使用すると、プレゼンテーションを **Read-Only** に設定できます。これにより、利用者はプレゼンテーションを開いたときに **Read-Only** の推奨を目にします。以下のサンプルコードは、Python で Aspose.Slides を利用してプレゼンテーションを **Read-Only** に設定する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
**Read-Only** の推奨は、PowerPoint プレゼンテーションの誤編集や偶発的な変更を防止することを目的としたものです。高度な知識を持ち、自分で解除できる人が編集しようとすれば、簡単に設定を取り除くことができます。もし不正な編集を確実に防止したい場合は、[more stringent protections that involve encryption and passwords](/slides/ja/python-java/password-protected-presentation/) を使用した方が適切です。 
{{% /alert %}} 

## **FAQ**

**「Read-Only recommended」はフルパスワード保護とどう違うのですか？**  
「Read-Only recommended」はファイルを読み取り専用モードで開くことを提案するだけで、簡単に回避できます。一方、[Password protection](/slides/ja/python-java/password-protected-presentation/) は実際に開封や編集を制限し、真のセキュリティ コントロールが必要な場合に適しています。

**「Read-Only recommended」を透かしと組み合わせて編集をさらに抑止できますか？**  
はい。推奨メッセージは [watermarks](/slides/ja/python-java/watermark/) と組み合わせて視覚的な抑止材料として利用できます。両者は別個の仕組みであり、相互に補完します。

**推奨が有効な状態でも、マクロや外部ツールでファイルを変更できますか？**  
はい。推奨はプログラムによる変更を阻止しません。自動化された編集を防止したい場合は、[passwords and encryption](/slides/ja/python-java/password-protected-presentation/) を使用してください。

**「Read-Only recommended」は [isEncrypted](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#isEncrypted) および [isWriteProtected](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#isWriteProtected) とどう関係していますか？**  
これらは異なるシグナルです。「Read-Only recommended」はソフトでオプション的な提示です。一方、[isWriteProtected](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#isWriteProtected) と [isEncrypted](https://reference.aspose.com/slides/ja/python-java/aspose.slides/protectionmanager/#isEncrypted) は、パスワードや暗号化に依存した実際の書き込み・読み取り制限を示します。