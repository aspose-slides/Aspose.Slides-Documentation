---
title: 制限事項とAPIの違い
type: docs
weight: 100
url: /python-java/limitations-and-api-differences/
keywords: "ノード, パワーポイント, 制限, api, 違い"
description: "Aspose.Slides for Python via Javaの制限事項とapiの違い。"
---
## **既知のバグ/制限事項**
パッケージ外のJavaクラス（`default`内）はインポートできません。
JVMサポートがないため、JVMをシャットダウンして再起動することはできません。また、1つのJVMのコピーを複数起動することもできません。
64ビットのPythonと32ビットのJavaを混ぜると、jpypeモジュールのインポート時にクラッシュします。

## **公開APIの違い**
以下のリスト（サンプルコードセグメントを含む）には、Aspose.Slides for JavaとAspose.Slides for Python via Java APIsの間のいくつかの違いが示されています。

### **ライブラリのインポート（パッケージの比較）**

**Aspose.Slides for Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()

```

### **新しいプレゼンテーションのインスタンス化**

**Aspose.Slides for Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **ストリーミングファイルと定数**

**Aspose.Slides for Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input = open("presentation.pptx", mode="rb")
data = input.read()
pres = Presentation.createPresentationFromBytes(data)
pres.save("result.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

### **Aspose.Slides for Python via Java APIの他の制限事項（Aspose.Slides for Java APIと比較）**

他の制限事項に関する詳細は、jpypeのドキュメントを参照してください： 
- https://jpype.readthedocs.io/en/latest/