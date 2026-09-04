---
title: 限制與 API 差異
type: docs
weight: 100
url: /zh-hant/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides for Python via Java
- API 差異
- Python
- Java
- JPype
- JVM 限制
- PowerPoint
description: "了解 Aspose.Slides for Java 與 Python via Java 之間的 JVM 限制與 API 差異，包括匯入、資源清理與檔案處理。"
---
## **概述**

Aspose.Slides for Python via Java 使用 JPype 從 Python 存取 Java 函式庫。以下範例比較兩種 API 在套件匯入、簡報建立與檔案處理上的差異。

## **已知限制**

- **JVM 生命週期：** JPype 在每個 Python 行程中只支援一個 JVM。關閉後無法在同一行程中重新啟動。請僅啟動一次，之後的簡報操作皆重複使用該 JVM。
- **架構相容性：** Python 與 Java 必須使用相同的架構。詳情請參閱[系統需求](/slides/zh-hant/python-java/system-requirements/#python-java-and-jpype-requirements)。

請參考[JPype 使用者指南](https://jpype.readthedocs.io/en/latest/userguide.html)以了解這些限制與 Java 相容性的細節。

## **公共 API 差異**

比較下方的 Java 與 Python 範例。欲取得 Python via Java 成員的詳細資訊，請參閱[API 參考](/slides/zh-hant/python-java/api-reference/)。

### **匯入函式庫**

Java 從 `com.aspose.slides` 匯入類別。Python 必須在啟動 JVM 之前先匯入 `asposeslides`，然後在 JVM 執行後再從 `asposeslides.api` 匯入類別。請使用[jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted)避免重複啟動已在執行的 JVM。

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
Python 範例會讓 JVM 持續執行至 Python 行程結束。在 Notebook 中，請在不同儲存格間重複使用已啟動的 JVM；如果已關閉 JVM，請在重新使用 Java 物件前重新啟動 Notebook 核心。
{{% /alert %}}

### **建立簡報**

Java 使用 `new` 關鍵字；Python 直接呼叫[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/)類別。請於 `finally` 區塊中使用[Presentation.dispose](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#dispose)釋放簡報資源。

兩個範例皆使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save)與[SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#pptx)儲存空白簡報。

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

### **讀取檔案與使用格式常數**

Java 可以從 Java 輸入串流載入簡報。Python 必須以二進位方式讀取檔案，並將取得的位元組傳給[Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#createpresentationfrombytes)。Python 的檔案物件並非 Java 輸入串流。

以下範例假設工作目錄中已有 `presentation.pptx`，並將副本儲存為 `result.pptx`。兩者皆會關閉輸入檔案並釋放簡報資源；Python 範例會將整個輸入檔案讀入記憶體。

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

## **常見問題**

**我需要為每個簡報重新啟動 JVM 嗎？**

不需要。保持 JVM 持續執行，視需求建立並釋放簡報物件。關閉 JVM 後，將無法在同一 Python 行程中執行任何 Java 操作。

**我可以直接以檔案路徑開啟簡報嗎？**

可以。[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 建構式接受檔案路徑。若簡報資料已以 Python 位元組形式取得，請使用基於位元組的輔助方法。

**在將 Java 範例轉換為 Python 時，我需要更改格式常數的名稱嗎？**

不需要。例如，[SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#pptx) 在兩個 API 中的拼寫與大小寫完全相同。