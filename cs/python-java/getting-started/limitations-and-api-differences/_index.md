---
title: Omezení a rozdíly API
type: docs
weight: 100
url: /cs/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides for Python via Java
- rozdíly API
- Python
- Java
- JPype
- omezení JVM
- PowerPoint
description: "Zjistěte více o omezeních JVM a rozdílech API mezi Aspose.Slides pro Java a Python přes Java, včetně importů, čištění prostředků a práce se soubory."
---
## **Přehled**

Aspose.Slides for Python via Java používá JPype pro přístup k Java knihovně z Pythonu. Níže uvedené příklady porovnávají importy balíčků, vytváření prezentací a práci se soubory v obou API.

## **Známá omezení**

- **Životní cyklus JVM:** JPype podporuje jeden JVM na jeden Python proces. Po jeho vypnutí jej nelze ve stejném procesu znovu spustit. Spusťte jej jednou a použijte jej pro následné operace s prezentacemi.
- **Kompatibilita architektur:** Python a Java musí mít odpovídající architektury. Podrobnosti najdete v [Požadavcích systému](/slides/cs/python-java/system-requirements/#python-java-and-jpype-requirements).

Podrobnosti o těchto omezeních a interoperabilitě s Javou najdete v [Příručce uživatele JPype](https://jpype.readthedocs.io/en/latest/userguide.html).

## **Rozdíly v veřejném API**

Porovnejte níže uvedené příklady v Javě i v Pythonu. Podrobnosti o členech Python via Java najdete v [Referenci API](/slides/cs/python-java/api-reference/).

### **Import knihovny**

Java importuje třídy z `com.aspose.slides`. V Pythonu nejprve importujete `asposeslides` před spuštěním JVM, poté importujete třídy z `asposeslides.api`, když JVM běží. Použijte [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) k zabránění opětovnému spuštění již běžícího JVM.

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

{{% alert color="info" title="Poznámka" %}}

Pythonové příklady nechávají JVM běžet až do ukončení Python procesu. V notebooku můžete aktivní JVM znovu použít napříč buňkami. Pokud byl již vypnut, restartujte jádro notebooku před dalším použitím Java objektů.

{{% /alert %}}

### **Vytvořit prezentaci**

Java používá klíčové slovo `new`; Python volá třídu [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) přímo. Uvolněte prostředky prezentace pomocí [Presentation.dispose](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#dispose) v bloku `finally`.

Oba příklady ukládají prázdnou prezentaci pomocí [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) a [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#pptx).

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

### **Číst soubory a používat konstanty formátu**

Java může načíst prezentaci z Java vstupního streamu. V Pythonu přečtěte soubor jako binární data a předáním získaných bajtů použijte [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#createpresentationfrombytes). Python objekt souboru není Java vstupní stream.

Níže uvedené příklady vyžadují existující `presentation.pptx` v pracovním adresáři a uloží kopii jako `result.pptx`. Oba uzavřou vstupní soubor a uvolní prostředky prezentace. Pythonový příklad načte celý vstupní soubor do paměti.

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

## **Často kladené otázky**

**Musím pro každou prezentaci restartovat JVM?**

Ne. Nechte JVM běžet a podle potřeby vytvářejte a uvolňujte objekty prezentace. Vypnutí JVM zabrání dalším Java operacím ve stejném Python procesu.

**Mohu otevřít prezentaci přímo ze souborové cesty?**

Ano. Konstruktor [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) přijímá cestu k souboru. Použijte pomocnou metodu založenou na bajtech, pokud jsou data prezentace již dostupná jako Python bajty.

**Mám měnit názvy konstant formátu při převodu Java příkladů do Pythonu?**

Ne. Například [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#pptx) používá stejný pravopis a kapitalizaci v obou API.