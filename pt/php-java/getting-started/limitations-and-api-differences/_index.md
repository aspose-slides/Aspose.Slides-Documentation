---
title: Limitações e Diferenças de API
type: docs
weight: 100
url: /pt/php-java/limitations-and-api-differences/
keywords:
- limitação
- diferenças de API
- comparação de pacotes
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Compare as limitações e diferenças de API entre Aspose.Slides para PHP via Java e Aspose.Slides para Java."
---
## **Diferenças na API Pública**

Esta lista, usando trechos de código de exemplo, demonstra certas diferenças entre Aspose.Slides para Java e Aspose.Slides para PHP via APIs Java.

### **Importando biblioteca (Comparação de Pacotes)**

**Aspose.Slides for Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides for PHP via Java**

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\sldes;
use aspose\sldes\Presentation;
```

### **Instanciando uma Nova Apresentação**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **Enums ou Constantes**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Exemplo**

**Aspose.Slides for Java**

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

public class Test
{
    public static void main(String[] args) throws Exception
    {
        // Instancia um objeto Presentation que representa um arquivo de apresentação
        Presentation pres = new Presentation();
        try
        {
            // Obtém o primeiro slide
            ISlide slide = pres.getSlides().get_Item(0);

            // Adiciona um autoshape com o tipo definido como linha
            slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
            pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
        }
        finally
        {
            if (pres != null) pres.dispose();
        }
    }
}
```

**Aspose.Slides for PHP via Java**

```php
<?php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$pres = new Presentation();
try
{
    // Obtém o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);

    // Adiciona um autoshape com o tipo definido como linha
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Outras Limitações do Aspose.Slides para PHP via API Java em Comparação com o Aspose.Slides para Java API**

Os namespaces do Aspose.Slides e as classes Java que eles utilizam são wrappers criados pelo PhpJavaBridge sobre as classes Java com o mesmo nome do pacote com.aspose.slides.

#### **1. Encapsulando Parâmetros e Argumentos Java**

Os parâmetros e argumentos que retornam e aceitam são wrappers sobre as classes Java com os mesmos nomes. Apenas strings e tipos numéricos são convertidos automaticamente. Arrays, coleções, bytes e booleanos não são convertidos.  

**Um erro comum:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Extendendo Classe Java e Operador instanceof**

Você não pode estender uma classe Java a partir de uma classe PHP. Como solução alternativa, pode implementar composição quando necessário.  
O operador instanceof funciona apenas para uma classe concreta. Não funciona para a interface ou classe pai de uma classe.  

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Um Array Java NÃO é um Array PHP**

Criação de array Java em PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. Comprimento de um Array Java**

``` php
$data->length; - does NOT work
```
solução alternativa
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. O Método Java Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
solução alternativa
``` php
$file = new Java("java.io.File", "embedOle.html");
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = new JavaClass("java.lang.Byte");
$htmlBytes = $Array->newInstance($Byte, $Array->getLength($file));
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file));
    $dis->readFully($htmlBytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
```

#### **6. O Método Java Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
```
solução alternativa
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```