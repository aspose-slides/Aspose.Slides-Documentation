---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /ja/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- Python 用 PowerPoint オートメーション
- Python PPT ライブラリ
- Python で PowerPoint を PDF にエクスポート
- Python で PowerPoint を SVG にエクスポート
- Python で PowerPoint を編集
- Microsoft Office なしの Python PowerPoint
- Python で PPTX を管理
- Python 用スライドプレビュー
- Python でスライドにオーディオを追加
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "ここから始めましょう: Aspose.Slides for Python via .NET をインストールし、最初のプレゼンテーションを作成し、一般的なタスクのガイド、API リファレンス、サポートを見つけてください。"
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET は、Microsoft PowerPoint や Microsoft Office を使用せずに、PowerPoint および OpenDocument プレゼンテーションの作成、読み取り、編集、変換を行うための Python ライブラリです。

PPT、PPTX、PPS、POT、ODP を読み書きでき、マクロ対応やテンプレートのバリエーションもサポートし、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へエクスポートします。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>はじめに</b></p>
<hr>
<p>開始</p>
<ul>
<li><a href="/slides/ja/python-net/installation/">インストール</a></li>
<li><a href="/slides/ja/python-net/create-presentation/">最初のプレゼンテーションを作成</a></li>
<li><a href="/slides/ja/python-net/getting-started/">開始ガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/python-net/supported-file-formats/">サポートされているファイル形式</a></li>
<li><a href="/slides/ja/python-net/evaluate-aspose-slides/">試用版の制限</a></li>
<li><a href="/slides/ja/python-net/licensing/">ライセンス</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides で構築</b></p>
<hr>
<p>一般的なタスク</p>
<ul>
<li><a href="/slides/ja/python-net/open-presentation/">プレゼンテーションを開く</a></li>
<li><a href="/slides/ja/python-net/save-presentation/">プレゼンテーションを保存</a></li>
<li><a href="/slides/ja/python-net/convert-powerpoint-to-pdf/">PDF に変換</a></li>
<li><a href="/slides/ja/python-net/convert-slide/">スライドを画像としてレンダリング</a></li>
<li><a href="/slides/ja/python-net/manage-text/">テキストと図形を編集</a></li>
</ul>
<p>Slides のワークフロー</p>
<ul>
<li><a href="/slides/ja/python-net/powerpoint-charts/">チャート</a></li>
<li><a href="/slides/ja/python-net/powerpoint-animation/">アニメーション</a></li>
<li><a href="/slides/ja/python-net/manage-media-files/">オーディオとビデオ</a></li>
<li><a href="/slides/ja/python-net/presentation-design/">スライド デザイン</a></li>
<li><a href="/slides/ja/python-net/merge-presentation/">プレゼンテーションを結合</a></li>
</ul>
<p>サンプル</p>
<ul>
<li><a href="/slides/ja/python-net/examples/">スライド要素別サンプル</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">GitHub のサンプル</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンスとサポート</b></p>
<hr>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">リリースノート</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">製品ページ</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">ダウンロード</a></li>
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

PyPI からパッケージをインストールします:

```bash
pip install aspose.slides
```

このパッケージには使用する .NET ランタイムが同梱されているため、.NET を別途インストールする必要はありません。Linux では libgdiplus と ICU ライブラリもインストールし、Debian または Ubuntu のシステム Python を使用する場合は仮想環境でコマンドを実行してください。macOS にはさらに前提条件があり、インストールは検証していません。コマンドや macOS の前提条件、サポートされている Python バージョンについては [インストール](/slides/ja/python-net/installation/) を参照してください。

*hello.py* としてコードを保存します:

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # CLOUD タイプのオートシェイプを追加します。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

`python hello.py` で実行します。スクリプトは現在のフォルダーに *new_presentation.pptx* を保存し、1 枚のスライドには「Hello, Aspose!」というテキストが入った雲形状が含まれます。ライセンスがない場合、保存されたファイルには評価用の透かしが入ります — 詳細は [ライセンス](/slides/ja/python-net/licensing/) を参照してください。プレゼンテーションの作成や内容の設定のその他の方法については、[プレゼンテーションの作成](/slides/ja/python-net/create-presentation/) をご覧ください。