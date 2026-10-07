---
title: Aspose.Slides for Python via Java
second_title: Aspose.Slides for Python
type: docs
weight: 47
url: /ja/python-java/
is_root: true
keywords:
- Aspose.Slides for Python via Java
- Python 用 PowerPoint ライブラリ
- Python で PowerPoint プレゼンテーションを管理
- Python で PowerPoint を読み書き
- Python で PowerPoint スライドを編集
- Python で PowerPoint を PDF にエクスポート
- Python で PowerPoint を SVG にエクスポート
- Python でスライドをプレビュー
- Python でスライドに音声と動画を追加
- Microsoft Office なしで PowerPoint
- Python
- Java
- Aspose.Slides
description: "ここから始めましょう: Aspose.Slides for Python via Java をインストールし、最初のプレゼンテーションを作成し、一般的なタスクのガイド、API リファレンス、サポート情報を見つけてください。"
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java は、Microsoft PowerPoint を使用せずに Python アプリケーションで PowerPoint および OpenDocument プレゼンテーションの作成、読み取り、編集、変換を行うためのライブラリで、JPype を介して Python プロセス内で Aspose.Slides Java エンジンを実行します。

PPT、PPTX、PPS、POT、ODP を読み込み・保存でき、マクロ対応やテンプレート バリアントも含み、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へエクスポートします。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>はじめに</b></p>
<hr>
<p>開始</p>
<ul>
<li><a href="/slides/ja/python-java/installation/">インストール</a></li>
<li><a href="/slides/ja/python-java/create-presentation/">最初のプレゼンテーションを作成</a></li>
<li><a href="/slides/ja/python-java/getting-started/">開始ガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/python-java/supported-file-formats/">対応ファイル形式</a></li>
<li><a href="/slides/ja/python-java/evaluate-aspose-slides/">試用版の制限</a></li>
<li><a href="/slides/ja/python-java/licensing/">ライセンス情報</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides で構築</b></p>
<hr>
<p>一般的なタスク</p>
<ul>
<li><a href="/slides/ja/python-java/open-presentation/">プレゼンテーションを開く</a></li>
<li><a href="/slides/ja/python-java/save-presentation/">プレゼンテーションを保存</a></li>
<li><a href="/slides/ja/python-java/convert-powerpoint-to-pdf/">PDF に変換</a></li>
<li><a href="/slides/ja/python-java/convert-slide/">スライドを画像としてレンダリング</a></li>
<li><a href="/slides/ja/python-java/manage-text/">テキストと図形を編集</a></li>
</ul>
<p>Slides ワークフロー</p>
<ul>
<li><a href="/slides/ja/python-java/powerpoint-charts/">チャート</a></li>
<li><a href="/slides/ja/python-java/powerpoint-animation/">アニメーション</a></li>
<li><a href="/slides/ja/python-java/manage-media-files/">オーディオとビデオ</a></li>
<li><a href="/slides/ja/python-java/presentation-design/">スライドデザイン</a></li>
<li><a href="/slides/ja/python-java/merge-presentation/">プレゼンテーションをマージ</a></li>
</ul>
<p>サンプル</p>
<ul>
<li><a href="/slides/ja/python-java/examples/">スライド要素別サンプル</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンスとサポート</b></p>
<hr>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">リリースノート</a></li>
<li><a href="/slides/ja/python-java/known-issues/">既知の問題</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">製品ページ</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">ダウンロード</a></li>
</ul>
<p>サポート</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">無料サポートフォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポートヘルプデスク</a></li>
</ul>
</div>
</div>

------

## **最初のプレゼンテーション**

Python と JDK をインストールし、`JAVA_HOME` を設定し、[インストール](/slides/ja/python-java/installation/) に記載の手順で仮想環境を作成・有効化します。その後、JPype と Aspose.Slides を PyPI からインストールします:

```sh
python -m pip install JPype1 aspose-slides-java
```

このコードを *hello.py* として保存します。Java 仮想マシンを起動し、新しいプレゼンテーションの最初のスライドにテキスト付きの雲形状を追加し、プレゼンテーションを保存します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 空白スライドを1枚含むプレゼンテーションを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # 雲形状を追加し、テキストを設定します。
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

同じ仮想環境で実行します:

```sh
python hello.py
```

このスクリプトは、テキスト「Hello, Aspose!」が付いた雲形状を含む 1 枚のスライドを持つ *new_presentation.pptx* を保存します。ライセンスがない場合、保存されたファイルには評価用の透かしが付加されます — 詳細は [ライセンス情報](/slides/ja/python-java/licensing/) をご覧ください。プレゼンテーションの作成や内容の設定については、[プレゼンテーションの作成](/slides/ja/python-java/create-presentation/) を参照してください。