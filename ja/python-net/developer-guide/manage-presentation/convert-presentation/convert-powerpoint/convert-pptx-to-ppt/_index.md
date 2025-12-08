---
title: PythonでPPTXをPPTに変換
linktitle: PPTXからPPT
type: docs
weight: 21
url: /ja/python-net/convert-pptx-to-ppt/
keywords:
- PPTXからPPT
- PPTXをPPTに変換
- PowerPointを変換
- プレゼンテーションを変換
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を .NET 経由で使用して PPTX を PPT に簡単に変換し、プレゼンテーションのレイアウトと品質を保ちながら PowerPoint の形式とのシームレスな互換性を確保します。"
---

## **概要**

Aspose.Slides for Python を使用すると、最新の PPTX プレゼンテーションをコードだけで従来の PPT 形式に変換できます。PPTX を開いて PPT としてエクスポートし、プレゼンテーションのコンテンツとレイアウトを維持することで、古いバージョンの PowerPoint と互換性のある結果が得られます。同じワークフローで PDF、XPS、ODP、HTML、画像などの他の出力も生成できるため、スクリプトや CI パイプライン、バッチ処理にスムーズに組み込むことができます。

## **PPTX を PPT に変換**

PPTX を PPT に変換するには、ファイル名と保存形式を [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスの [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) メソッドに渡すだけです。下の Python の例は、デフォルトオプションを使用して PPTX から PPT にプレゼンテーションを変換します。
```py
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = slides.Presentation("presentation.pptx")

# プレゼンテーションを PPT ファイルとして保存します。
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```


## **FAQ**

**PPTX のすべての効果や機能は、従来の PPT (97–2003) 形式に保存するときに保持されますか？**

必ずしもそうではありません。PPT 形式は新しい機能の一部（例: 特定の効果、オブジェクト、動作）をサポートしていないため、変換時に機能が簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存するとプレゼンテーション全体が対象になります。特定のスライドだけを変換するには、そのスライドだけを含む新しいプレゼンテーションを作成して PPT として保存します。または、スライド単位の変換パラメーターに対応したサービスや API を使用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードで開くことができ、保存する PPT に対しても [保護/暗号化設定を構成](/slides/ja/python-net/password-protected-presentation/) を設定できます。

**その他参照:**
- [Python で PPT & PPTX を PDF に変換 | 詳細オプション](/slides/ja/python-net/convert-powerpoint-to-pdf/)
- [Python で PowerPoint プレゼンテーションを XPS に変換](/slides/ja/python-net/convert-powerpoint-to-xps/)
- [Python で PowerPoint プレゼンテーションを HTML に変換](/slides/ja/python-net/convert-powerpoint-to-html/)
- [Python で PowerPoint スライドを PNG に変換](/slides/ja/python-net/convert-powerpoint-to-png/)