---
title: 制限と API の違い
type: docs
weight: 100
url: /ja/python-java/limitations-and-api-differences/
keywords:
- Python via Java 用 Aspose.Slides
- API の違い
- Python
- Java
- JPype
- JVM の制限
- PowerPoint
description: "Aspose.Slides for Java と Python via Java の間の JVM の制限や API の違い、インポート、リソースのクリーンアップ、ファイル処理について学びます。"
---
## **概要**

Aspose.Slides for Python via Java は JPype を使用して、Python から Java ライブラリにアクセスします。以下の例では、パッケージのインポート、プレゼンテーションの作成、ファイル操作を 2 つの API で比較しています。

## **既知の制限**

- **JVM ライフサイクル:** JPype は Python プロセスあたり 1 つの JVM をサポートします。シャットダウンした後は同じプロセスで再起動できません。1 回起動したら、以降のプレゼンテーション操作で再利用してください。
- **アーキテクチャの互換性:** Python と Java は同じアーキテクチャである必要があります。詳細は[システム要件](/slides/ja/python-java/system-requirements/#python-java-and-jpype-requirements)をご覧ください。

これらの制限および Java の相互運用性の詳細については、[JPype ユーザーガイド](https://jpype.readthedocs.io/en/latest/userguide.html)を参照してください。

## **パブリック API の違い**

以下の Java と Python の例を比較してください。Python via Java のメンバーの詳細については、[API リファレンス](/slides/ja/python-java/api-reference/)をご覧ください。

### **ライブラリのインポート**

Java は `com.aspose.slides` からクラスをインポートします。Python では JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になったら `asposeslides.api` からクラスをインポートします。既に起動している JVM を再度起動しないように、[jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) を使用してください。

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
Python の例は、Python プロセスが終了するまで JVM を起動したままにします。ノートブックでは、セル間でアクティブな JVM を再利用してください。すでにシャットダウンされている場合は、Java オブジェクトを再度使用する前にノートブック カーネルを再起動してください。
{{% /alert %}}

### **プレゼンテーションの作成**

Java は `new` キーワードを使用しますが、Python は[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/)クラスを直接呼び出します。`finally` ブロック内で[Presentation.dispose](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#dispose)を使用してプレゼンテーションのリソースを解放してください。

両方の例では、[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) と [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#pptx) を使用して空のプレゼンテーションを保存します。

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ファイルの読み込みとフォーマット定数の使用**

Java は Java の入力ストリームからプレゼンテーションをロードできます。Python ではファイルをバイナリ データとして読み取り、得られたバイト列を[Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#createpresentationfrombytes)に渡します。Python のファイル オブジェクトは Java の入力ストリームではありません。

以下の例では、作業ディレクトリに既存の `presentation.pptx` があることが前提で、コピーを `result.pptx` として保存します。両方の例で入力ファイルを閉じ、プレゼンテーションのリソースを解放します。Python の例は入力ファイル全体をメモリに読み込みます。

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **よくある質問**

**各プレゼンテーションごとに JVM を再起動する必要がありますか？**

いいえ。JVM を常に起動したままにし、必要に応じてプレゼンテーションオブジェクトを作成および破棄してください。JVM をシャットダウンすると、同じ Python プロセス内での Java 操作はできなくなります。

**ファイル パスから直接プレゼンテーションを開くことはできますか？**

はい。Presentation コンストラクターはファイル パスを受け付けます。プレゼンテーション データが既に Python のバイトとして利用可能な場合は、バイトベースのヘルパーを使用してください。

**Java の例を Python に翻訳する際にフォーマット定数名を変更する必要がありますか？**

いいえ。たとえば、[SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#pptx) は両方の API で同じ綴りと大文字小文字が使用されています。