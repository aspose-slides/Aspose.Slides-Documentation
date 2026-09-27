---
title: インストール
type: docs
weight: 70
url: /ja/python-java/installation/
keywords:
- Aspose.Slides をダウンロード
- Aspose.Slides をインストール
- Aspose.Slides のインストール
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Windows、Linux、macOS 上で Python 用 Aspose.Slides via Java をインストールし、Java と JPype を設定し、動作する例でセットアップを検証します。"
---
Aspose.Slides for Python via Java は Windows、Linux、macOS で動作します。JPype を使用して Python から Java ライブラリにアクセスします。Microsoft PowerPoint は必要ありません。

## **前提条件**

Python パッケージをインストールする前に、[System Requirements](/slides/ja/python-java/system-requirements/) を満たす Python と JDK をインストールしてください。そのページには、対応バージョン、アーキテクチャ要件、JPype をソースからビルドするために必要な依存関係が記載されています。

`JAVA_HOME` は JDK のインストールディレクトリ（`bin` サブディレクトリではなく）に設定し、JDK の `bin` ディレクトリを `PATH` に追加します。環境変数を変更したら新しいターミナルを開いてください。

## **PyPI からインストール**

ターミナル上で以下のコマンドを実行してください。Python の対話プロンプトでは実行しません。プロジェクトディレクトリと仮想環境を作成し、パッケージを他のプロジェクトから分離して管理します。

### **Windows**

`PATH` 上に `python` として利用できる Python インタプリタがあることを確認し、コマンドプロンプトで以下を実行します。

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux and macOS**

`python3` として利用できる Python バージョンがあることを確認し、Bash または zsh で以下を実行します。

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Debian または Ubuntu で、`ensurepip` が利用できないために環境作成に失敗した場合は、`sudo apt-get install python3-venv` で `python3-venv` パッケージをインストールし、環境作成コマンドを再実行してください。別途インストールした Python バージョンには、対応するバージョン固有の `venv` パッケージが必要になることがあります。

### **パッケージのインストール**

仮想環境が有効な状態で、JPype と Aspose.Slides をインストールします。

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

`python -m pip` を使用することで、アプリケーション実行時に使用するインタプリタ用にパッケージがインストールされます。

既存の Aspose.Slides インストールを更新するには、同じ環境で `python -m pip install --upgrade aspose-slides-java` を実行してください。

## **ZIP アーカイブからインストール**

[Aspose.Slides downloads page](https://releases.aspose.com/slides/ja/python-java/) からライブラリを取得して使用することもできます。

1. [Prerequisites](#prerequisites) に記載の手順で Python と Java をインストールします。
2. 上記手順に従って仮想環境を作成し、アクティブ化します。
3. `python -m pip install JPype1` で JPype をインストールします。
4. Aspose.Slides for Python via Java の ZIP アーカイブをダウンロードし、展開します。
5. 展開された `asposeslides` パッケージディレクトリを見つけます。その内容（`lib` ディレクトリや JAR ファイルを含む）をそのまま保管してください。
6. 次のセクションの `example.py` を `asposeslides` ディレクトリと同じ場所に配置し、Python がパッケージをインポートできるようにします。アーカイブには既に `example.py` が `asposeslides` の隣にあるので、下記のものに置き換えてください。

## **インストールの検証**

以下のコードを `example.py` として保存します。テキストボックスを含むプレゼンテーションを作成し、カレントディレクトリに `out.pptx` として保存します。

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

仮想環境が有効な状態で、`example.py` があるディレクトリで以下を実行します。

```sh
python example.py
```

`asposeslides` のインポートは JVM 起動前にバンドルされた Java ライブラリを登録します。JVM 起動後に `asposeslides.api` をインポートし、終了時にプレゼンテーションリソースを解放してください。

{{% alert color="info" title="Note" %}}
ライセンスがない場合、出力には評価用の透かしが含まれます。評価の制限や一時ライセンス情報については [Evaluate Aspose.Slides](/slides/ja/python-java/evaluate-aspose-slides/) を参照してください。
{{% /alert %}}

## **FAQ**

**Python が JVM を見つけられない、またはロードできないと報告するのはなぜですか？**

`JAVA_HOME` が Python と JPype のインストール環境に適合した JDK を指しているか確認してください（[System Requirements](/slides/ja/python-java/system-requirements/) を参照）。追加の確認項目は [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html) をご覧ください。

**インストール後に `asposeslides` が見つからないと Python が報告するのはなぜですか？**

別の Python インタプリタ向けにパッケージがインストールされた可能性があります。インストール時に使用した仮想環境をアクティブ化し、`python -m pip show aspose-slides-java` を実行してください。ZIP インストールの場合は、`asposeslides` ディレクトリがスクリプトと同じ場所にあるか、Python のモジュール検索パスに含まれていることを確認してください。

**ノートブックで例を繰り返し実行できますか？**

この例はスタンドアロンの Python プロセスを想定しています。ノートブックでの繰り返し実行に適応する前に、[Limitations and API Differences](/slides/ja/python-java/limitations-and-api-differences/#import-the-library) に記載の JVM ライフサイクルとノートブックに関するガイダンスをご確認ください。

**`pip` が `CERTIFICATE_VERIFY_FAILED` で失敗するのはなぜですか？**

ネットワークが HTTPS インスペクションプロキシを使用している場合、`pip` はその証明機関を信頼する必要があります。`--cert` オプションまたは `PIP_CERT` 環境変数で信頼できる CA バンドルを設定し、[pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/) に従ってください。必要な構成は使用しているネットワークと `pip` のバージョンに依存します。