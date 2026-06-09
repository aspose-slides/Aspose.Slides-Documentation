---
title: Limitações e Diferenças de API
type: docs
weight: 100
url: /pt/python-java/limitations-and-api-differences/
keywords: "nó, powerpoint, limitação, API, diferenças"
description: "Limitações e diferenças de API do Aspose.Slides para Python via Java."
---
## **Erros Conhecidos/Limitacoes**
Classes Java fora de um pacote (no `default`) não podem ser importadas.  
Devido à falta de suporte à JVM, você não pode desligar a JVM e depois reiniciá‑la. Também não pode iniciar mais de uma cópia da JVM.  
Misturar Python de 64 bits com Java de 32 bits e vice‑versa causa falha ao importar o módulo jpype.

## **Diferenças na API Pública**
A lista a seguir (com trechos de código de exemplo) mostra algumas diferenças entre Aspose.Slides para Java e Aspose.Slides para Python via APIs Java.

### **Importando biblioteca (Comparações de Pacotes)**

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

### **Instanciando uma nova Apresentação**

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

### **Transmissão de Arquivos e Constantes**

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

### **Outras Limitações do Aspose.Slides para Python via API Java comparado ao Aspose.Slides para API Java**

Para obter mais informações sobre outras limitações, consulte a documentação do jpype: 
- https://jpype.readthedocs.io/en/latest/