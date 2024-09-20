---
title: Ограничения и различия в API
type: docs
weight: 100
url: /python-java/limitations-and-api-differences/
keywords: "узел, powerpoint, ограничение, api, различия"
description: "Ограничения и различия в API Aspose.Slides для Python через Java."
---
## **Известные ошибки/ограничения**
Java-классы вне пакета (в `default`) не могут быть импортированы.
Из-за отсутствия поддержки JVM вы не можете завершить работу JVM и затем перезапустить её. Также вы не можете запустить более одной копии JVM.
Смешение 64-битного Python с 32-битной Java и наоборот вызывает сбой при импорте модуля jpype.

## **Различия в публичном API**
Следующий список (с примерами кода) показывает некоторые различия между Aspose.Slides для Java и Aspose.Slides для Python через Java API.

### **Импорт библиотеки (Сравнение пакетов)**

**Aspose.Slides для Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides для Python через Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()

```

### **Создание новой Презентации**

**Aspose.Slides для Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides для Python через Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **Потоковые файлы и константы**

**Aspose.Slides для Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides для Python через Java**

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

### **Другие ограничения Aspose.Slides для Python через Java API по сравнению с Aspose.Slides для Java API**

Для получения дополнительной информации об остальных ограничениях, пожалуйста, обратитесь к документации jpype:
- https://jpype.readthedocs.io/en/latest/

