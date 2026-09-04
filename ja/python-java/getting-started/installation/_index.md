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
description: "Windows、Linux、macOS 上で Python 用 Aspose.Slides for Java をインストールし、Java と JPype を構成し、動作するサンプルでセットアップを確認します。"
---
Aspose.Slides for Python via Java は Windows、Linux、macOS で動作します。JPype を使用して Python から Java ライブラリにアクセスします。Microsoft PowerPoint は必要ありません。

## **前提条件**

Python パッケージをインストールする前に、[System Requirements](/slides/ja/python-java/system-requirements/) を満たす Python と JDK をインストールしてください。そのページには、対応バージョン、アーキテクチャ要件、および JPype をソースからビルドするために必要な依存関係が記載されています。

`JAVA_HOME` を JDK のインストールディレクトリ（`bin` サブディレクトリではなく）に設定し、JDK の `bin` ディレクトリを `PATH` に追加します。環境変数を変更したら、新しいターミナルを開いてください。

## **PyPI からインストール**

ターミナルで以下のコマンドを実行してください。Python の対話プロンプトではなく、ターミナルで実行します。プロジェクト用ディレクトリと仮想環境を作成し、パッケージを他のプロジェクトから分離して管理します。

### **Windows**

`PATH` 上に `python` として利用できる Python インタープリターがある状態で、コマンドプロンプトに以下のコマンドを実行します。

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux と macOS**

`python3` として利用できる Python バージョンがある状態で、Bash または zsh に以下のコマンドを実行します。

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Debian または Ubuntu で環境作成に失敗し、`ensurepip` が利用できない場合は、`sudo apt-get install python3-venv` で `python3-venv` パッケージをインストールし、環境作成コマンドを再実行してください。別途インストールした Python バージョンでは、対応するバージョン固有の `venv` パッケージが必要になることがあります。

### **パッケージのインストール**

仮想環境をアクティブにした状態で、JPype と Aspose.Slides をインストールします。

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

`python -m pip` を使用することで、アプリケーションを実行するインタープリター向けにパッケージがインストールされます。

既存の Aspose.Slides インストールを更新する場合は、同じ環境で `python -m pip install --upgrade aspose-slides-java` を実行してください。

## **ZIP アーカイブからインストール**

[Aspose.Slides ダウンロードページ](https://releases.aspose.com/slides/ja/python-java/) からもライブラリを使用できます。

1. [前提条件](#前提条件) に記載の方法で Python と Java をインストールします。  
2. 上記手順に従って仮想環境を作成し、アクティブにします。  
3. `python -m pip install JPype1` で JPype をインストールします。  
4. Aspose.Slides for Python via Java の ZIP アーカイブをダウンロードして展開します。  
5. 展開された `asposeslides` パッケージディレクトリを確認し、`lib` ディレクトリや JAR ファイルを含む内容をそのまま保持します。  
6. 次のセクションの `example.py` を `asposeslides` ディレクトリと同じ階層に配置し、Python がパッケージをインポートできるようにします。

## **インストールの確認**

以下のコードを `example.py` という名前で保存してください。テキストボックスを含むプレゼンテーションを作成し、カレントディレクトリに `out.pptx` として保存します。

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

仮想環境をアクティブにした状態で、`example.py` があるディレクトリで次のコマンドを実行します。

```sh
python example.py
```

`asposeslides` のインポートにより、JVM 起動前にバンドルされた Java ライブラリが登録されます。JVM 起動後に `asposeslides.api` をインポートし、終了時にプレゼンテーションのリソースを解放してください。

{{% alert color="info" title="Note" %}}
ライセンスがない場合、出力には評価用の透かしが入ります。評価の制限事項および一時ライセンス情報については、[Evaluate Aspose.Slides](/slides/ja/python-java/evaluate-aspose-slides/) を参照してください。
{{% /alert %}}

## **FAQ**

**Python が JVM を見つけられない、またはロードできないと報告するのはなぜですか？**

`JAVA_HOME` が Python と JPype のインストール環境に適合した JDK を指しているか確認してください。詳細は [System Requirements](/slides/ja/python-java/system-requirements/) を参照してください。追加のチェック項目は [JPype インストールトラブルシューティングガイド](https://jpype.readthedocs.io/en/latest/install.html) をご覧ください。

**インストール後に `asposeslides` が見つからないと Python が報告するのはなぜですか？**

パッケージが別の Python インタープリター向けにインストールされた可能性があります。インストールに使用した仮想環境をアクティブにし、`python -m pip show aspose-slides-java` を実行して確認してください。ZIP インストールの場合は、`asposeslides` ディレクトリがスクリプトと同じ場所にあるか、Python のモジュール検索パスに含まれていることを確認してください。

**ノートブックで例を繰り返し実行できますか？**

例は単一の Python プロセスでの実行を想定しています。ノートブックでの繰り返し実行に適用する前に、[制限事項と API の違い](/slides/ja/python-java/limitations-and-api-differences/#import-the-library) にある JVM のライフサイクルとノートブックに関するガイダンスをご確認ください。

**pip が `CERTIFICATE_VERIFY_FAILED` で失敗するのはなぜですか？**

ネットワークが HTTPS インスペクションプロキシを使用している場合、pip にその証明書機関を信頼させる必要があります。pip の `--cert` オプションまたは `PIP_CERT` 環境変数で信頼できる CA バンドルを設定してください。設定方法はネットワーク環境と pip のバージョンに依存します。詳細は [pip HTTPS 証明書の設定] (https://pip.pypa.io/en/stable/topics/https-certificates/) を参照してください。