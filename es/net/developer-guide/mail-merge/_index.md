---
title: Automatizar la personalización de presentaciones con Mail Merge
linktitle: Mail Merge
type: docs
weight: 233
url: /es/net/mail-merge/
keywords:
- Combinar correspondencia
- personalización de presentaciones
- plantilla de presentación
- marcadores de posición de texto
- fuente de datos
- CSV
- Excel
- XLSX
- JSON
- XML
- fusionar datos
- generar presentaciones
- .NET
- C#
- Aspose.Slides
description: "Aprenda a usar Mail Merge en Aspose.Slides for .NET para rellenar plantillas de presentación con datos y generar presentaciones de PowerPoint personalizadas a partir de fuentes CSV, Excel, JSON y XML."
---
# Combinar correspondencia en presentaciones de PowerPoint

Aspose.Slides for .NET permite generar presentaciones de PowerPoint de forma automática utilizando una plantilla y una fuente de datos. Combinar correspondencia rellena los marcadores de posición de la plantilla con datos y crea ya sea una única presentación que contiene diapositivas de plantilla repetidas para cada conjunto de datos o una presentación separada para cada conjunto de datos.

Esta funcionalidad es útil para generar catálogos de productos, presentaciones personalizadas, informes, certificados, propuestas, listas de precios y otros documentos en los que la estructura de la presentación permanece igual mientras el contenido varía.

![Combinar correspondencia: antes y después](mail-merge-before-after.png)


## Cómo funciona la combinación de correspondencia

La combinación de correspondencia utiliza una presentación de PowerPoint como plantilla y sustituye los marcadores de posición por valores de una fuente de datos.

![Flujo de trabajo de combinar correspondencia](mail-merge-workflow.png)

Un marcador de posición es un nombre de campo encerrado entre llaves dobles, como `{{title}}` o `{{price}}`. Los marcadores de posición pueden colocarse en el texto de formas, celdas de tabla, formas agrupadas y notas del orador.

Por ejemplo, una diapositiva de plantilla puede contener el siguiente texto:

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

Cuando la fuente de datos contiene los siguientes valores:

| Campo | Valor |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

La combinación de correspondencia sustituye los marcadores de posición por los valores correspondientes, produciendo una diapositiva con la información real del producto.

Los nombres de campo no distinguen entre mayúsculas y minúsculas, por lo que `{{title}}` y `{{Title}}` hacen referencia al mismo campo.

Se aplican las siguientes reglas al sustituir marcadores de posición:

- Los marcadores de posición se sustituyen en diapositivas, incluidas formas agrupadas y celdas de tabla, y en notas del orador.
- Los marcadores de posición en diapositivas maestros y de diseño no se sustituyen.
- Un marcador de posición cuyo campo no está presente en el conjunto de datos permanece sin cambios.
- Un valor de campo vacío sustituye su marcador de posición por una cadena vacía.
- El texto insertado hereda el formato del primer carácter del marcador de posición.
- Los valores no deben contener texto de marcador de posición, porque el texto insertado podría volver a procesarse y ser sustituido por otro campo.

La presentación de plantilla original no se modifica durante la operación de combinación y debe contener al menos una diapositiva.

## Orígenes de datos compatibles

La combinación de correspondencia admite dos formas de proporcionar datos:

- Crear una fuente de datos programáticamente mediante `IMailMergeDataSource`.
- Leer datos de un archivo o flujo CSV, XLSX, JSON o XML.

El formato de los datos se detecta por su contenido, no por la extensión del archivo. También se admiten flujos que no soportan búsqueda.

La fuente de datos debe contener al menos un conjunto de datos. Cada conjunto de datos representa una copia de la plantilla que se rellenará con sus valores.

Si el contenido de los datos no se puede reconocer como un formato admitido, se lanza `NotSupportedException`. Si el contenido se reconoce pero no cumple con los requisitos de formato, se lanza `InvalidDataException`. El mensaje de la excepción contiene la ubicación del error en los datos.

### JSON

La fuente de datos JSON debe tener un objeto raíz que contenga una matriz `sets`. Cada elemento de la matriz representa un conjunto de datos y debe contener una matriz `fields`. Cada campo debe tener una cadena `name` y una cadena `value`.

La propiedad opcional `version` debe ser `"1.0"` y la propiedad opcional `type` de un campo debe ser `"text"`. Los nombres de las propiedades distinguen entre mayúsculas y minúsculas. Las propiedades desconocidas se ignoran.

Los datos JSON se leen como UTF-8, o como UTF-16 cuando los datos comienzan con una marca de orden de bytes (BOM).

El siguiente ejemplo contiene dos conjuntos de datos:

```json
{
  "version": "1.0",
  "sets": [
    {
      "fields": [
        { "name": "title", "value": "Laptop X1" },
        { "name": "price", "value": "$999" }
      ]
    },
    {
      "fields": [
        { "name": "title", "value": "Tablet S2" },
        { "name": "price", "value": "$499" }
      ]
    }
  ]
}
```

### XML

La fuente de datos XML debe tener un elemento raíz `template` que contenga el elemento `sets`. Cada elemento `set` contiene elementos `field`, y cada campo debe contener elementos `name` y `value`.

Un elemento `value` vacío se trata como una cadena vacía. Los nombres de los elementos distinguen entre mayúsculas y minúsculas. Los elementos y comentarios desconocidos se ignoran. La codificación se determina mediante la declaración XML. No se permiten definiciones de tipo de documento (DTD).

```xml
<?xml version="1.0" encoding="utf-8"?>
<template>
  <sets>
    <set>
      <field>
        <name>title</name>
        <value>Laptop X1</value>
      </field>
      <field>
        <name>price</name>
        <value>$999</value>
      </field>
    </set>
    <set>
      <field>
        <name>title</name>
        <value>Tablet S2</value>
      </field>
      <field>
        <name>price</name>
        <value>$499</value>
      </field>
    </set>
  </sets>
</template>
```

### CSV

Los datos CSV utilizan punto y coma como separador de valores.

La primera fila contiene los nombres de los campos y termina en el primer nombre de campo vacío. Cada fila posterior representa un conjunto de datos. Los datos terminan en la primera fila vacía.

Se aplican las siguientes reglas:

- Los valores que faltan al final de una fila se tratan como cadenas vacías.
- Los valores más allá de los nombres de campo definidos se ignoran.
- Un valor que contenga punto y coma, comilla o salto de línea debe estar entre comillas.
- Las comillas dentro de un valor entre comillas deben duplicarse.
- Los datos se leen como UTF-8, o como UTF-16 cuando comienzan con una marca de orden de bytes (BOM).

Ejemplo:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### XLSX

Los datos XLSX se leen de la primera hoja de cálculo.

La hoja sigue las mismas reglas que CSV:

- La primera fila contiene los nombres de los campos y termina en la primera celda vacía.
- Cada fila posterior representa un conjunto de datos.
- Los datos terminan en la primera fila vacía.
- Las celdas vacías se tratan como cadenas vacías.
- Los valores numéricos se convierten a texto utilizando la cultura invariante.

## Creación de una única presentación

El método `MergeToSinglePresentation` crea una presentación que contiene una copia de las diapositivas de la plantilla para cada conjunto de datos. Cada copia se rellena con los datos correspondientes.

El orden de los conjuntos de datos determina el orden de los grupos de diapositivas en la presentación resultante.

### Combinar datos desde un archivo

El siguiente ejemplo carga una plantilla y un archivo de datos JSON, crea una única presentación que contiene las diapositivas para todos los conjuntos de datos y guarda el resultado.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, "products.json"))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

Los datos también pueden leerse desde un flujo. El flujo se lee a partir de su posición actual y no es cerrado por la operación de combinación de correspondencia.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xml"))
using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, data))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

### Creación de una fuente de datos en código

Puede crear una fuente de datos programáticamente usando `MailMergeDataSource` y `MailMergeDataSet`. Añada un conjunto de datos por cada registro y defina sus campos mediante el método `AddText`.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet laptop = source.AddDataSet();
laptop.AddText("title", "Laptop X1");
laptop.AddText("price", "$999");

IMailMergeDataSet tablet = source.AddDataSet();
tablet.AddText("title", "Tablet S2");
tablet.AddText("price", "$499");

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, source))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

En este ejemplo, las diapositivas de la plantilla se repiten dos veces: una para el portátil y otra para la tableta. Los marcadores de posición se rellenan con los valores definidos en cada conjunto de datos.

## Creación de presentaciones múltiples

Si necesita una presentación separada para cada conjunto de datos, utilice el método `MergeToMultiplePresentations`.

Este método procesa los conjuntos de datos uno a uno, crea una presentación a partir de la plantilla, la rellena con los datos actuales y pasa la presentación resultante a un controlador.

El controlador se invoca una vez por cada conjunto de datos, siguiendo el orden original de los datos.

### Guardar cada presentación

El siguiente ejemplo lee datos de un archivo CSV y guarda cada presentación generada como un archivo separado.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.csv",
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

La propiedad `args.Index` proporciona el índice basado en cero del conjunto de datos actual. En el ejemplo, se utiliza para generar nombres de archivo secuenciales a partir de `product_1.pptx`.

Los datos también pueden leerse desde un flujo:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xlsx"))
using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        data,
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

### Usar valores del conjunto de datos para nombrar archivos

El controlador recibe tanto la presentación generada como la información sobre el conjunto de datos utilizado para crearla. Puede usar los valores del conjunto de datos para crear nombres de archivo significativos.

Por ejemplo, el siguiente código guarda cada presentación utilizando el título del producto:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string title = args.DataSet.GetText("title");
            string fileName = title != null
                ? title
                : "product_" + (args.Index + 1);

            presentation.Save(fileName + ".pptx", SaveFormat.Pptx);
        });
}
```

La propiedad `DataSet` devuelve el conjunto de datos utilizado para rellenar la presentación actual. El método `GetText` recupera el valor de un campo especificado, o `null` si el campo no está presente.

Esto le permite usar los valores de los datos para nombrar archivos, organizar la salida o aplicar procesamiento adicional en el controlador.

## Manejo de presentaciones generadas

`MergeToMultiplePresentations` utiliza el delegado `MailMergedPresentationHandler` para procesar cada presentación generada.

El controlador recibe dos argumentos:

- `presentation` — la presentación creada a partir de la plantilla y rellenada con el conjunto de datos actual.
- `args` — información sobre la presentación generada, incluido el índice del conjunto de datos y el propio conjunto de datos.

La presentación generada es propiedad de la operación de combinación de correspondencia y se elimina inmediatamente después de que el controlador devuelva. Por lo tanto, debe guardarla o copiar cualquier dato necesario dentro del controlador. No conserve una referencia a ella después de que el controlador devuelva ni la elimine manualmente.

El controlador se ejecuta en el hilo que llama, una presentación a la vez, siguiendo el orden de los conjuntos de datos. Sólo una presentación generada se mantiene en memoria simultáneamente, lo que hace que este enfoque sea adecuado para procesar fuentes de datos grandes sin mantener todas las presentaciones generadas en memoria a la vez.

Si el controlador lanza una excepción, la operación de combinación de correspondencia se detiene y la excepción se propaga al llamador sin cambios. Las presentaciones ya procesadas permanecen intactas y los conjuntos de datos restantes no se procesan.

El siguiente ejemplo guarda las presentaciones generadas en un directorio dedicado:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

string outputFolder = "output";
Directory.CreateDirectory(outputFolder);

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string path = Path.Combine(
                outputFolder,
                "product_" + (args.Index + 1) + ".pptx");

            presentation.Save(path, SaveFormat.Pptx);
        });
}
```

## Trabajo con datos de combinación de correspondencia

La clase `MailMergeDataSource` representa una colección ordenada de conjuntos de datos. Puede usarse para crear datos en código, inspeccionar el número de conjuntos de datos y acceder a conjuntos de datos individuales por índice.

### Obtener el número de conjuntos de datos

La propiedad `Count` devuelve el número de conjuntos de datos en la fuente.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### Acceder a un conjunto de datos por índice

La propiedad `Item(int)` permite acceder a un conjunto de datos en el índice basado en cero especificado.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Este ejemplo recupera el título del segundo conjunto de datos.

### Añadir campos de texto

El método `AddText` añade un campo de texto con nombre a un conjunto de datos. El valor del campo sustituye todos los marcadores de posición coincidentes en la plantilla.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Un valor vacío elimina el marcador de posición correspondiente del texto resultante. Si el campo no se añade al conjunto de datos, el marcador de posición permanece sin cambios.

### Leer campos de texto

El método `GetText` recupera el valor de un campo por nombre. Los nombres de los campos no distinguen entre mayúsculas y minúsculas.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Si el campo no existe o el nombre de campo especificado es `null`, `GetText` devuelve `null`.

## Resumen

Combinar correspondencia en Aspose.Slides for .NET proporciona una forma cómoda de generar presentaciones basadas en datos a partir de una plantilla reutilizable.

Puede usarlo para:

- Rellenar plantillas de presentación con valores de fuentes de datos.
- Generar una única presentación que contiene diapositivas de plantilla repetidas para varios conjuntos de datos.
- Crear una presentación separada para cada conjunto de datos.
- Leer datos de archivos o flujos CSV, XLSX, JSON y XML.
- Construir fuentes de datos directamente en código.
- Procesar y guardar presentaciones generadas secuencialmente mediante un controlador.

Al combinar plantillas reutilizables con datos estructurados, puede automatizar la creación de un gran número de presentaciones manteniendo el diseño de la plantilla y la lógica de procesamiento de datos por separado.

## Preguntas frecuentes

### ¿Puedo usar el mismo marcador de posición varias veces en una plantilla?

Sí. Cada aparición de un marcador de posición con un nombre de campo coincidente se sustituye por el valor correspondiente del conjunto de datos actual.

### ¿Los nombres de los campos distinguen entre mayúsculas y minúsculas?

No. Los nombres de los campos y los marcadores de posición no distinguen entre mayúsculas y minúsculas. Por ejemplo, `{{title}}`, `{{Title}}` y `{{TITLE}}` hacen referencia al mismo campo.

### ¿Qué ocurre si falta un campo en un conjunto de datos?

Si el conjunto de datos no contiene un campo referenciado por un marcador de posición, ese marcador de posición permanece sin cambios en la presentación generada.

### ¿Qué ocurre si un campo tiene un valor vacío?

Un valor de campo vacío sustituye el marcador de posición por una cadena vacía. El texto del marcador de posición se elimina, dejando ningún texto en su lugar.

### ¿Puedo conservar el formato de un marcador de posición al sustituirlo?

El texto de sustitución hereda el formato del primer carácter del marcador de posición. Aplique el formato deseado al texto del marcador de posición en la plantilla antes de realizar la combinación.

### ¿La combinación de correspondencia sustituye marcadores de posición en diapositivas maestras o de diseño?

No. La combinación de correspondencia sustituye los marcadores de posición en el contenido admitido de las diapositivas de la presentación, incluidas formas, formas agrupadas, celdas de tabla y notas del orador. Los marcadores de posición en diapositivas maestras y de diseño no se sustituyen.

### ¿Se modifica la presentación de plantilla durante la combinación?

No. La plantilla original no se modifica mediante la operación de combinación. Puede reutilizarla para generar presentaciones a partir de la misma o diferentes fuentes de datos.

### ¿Puedo generar una presentación separada para cada conjunto de datos?

Sí. Use `MergeToMultiplePresentations` y guarde cada presentación generada dentro del controlador. El controlador se llama secuencialmente para cada conjunto de datos.

### ¿Puedo combinar todos los conjuntos de datos en una sola presentación?

Sí. Use `MergeToSinglePresentation`. Crea una única presentación de salida que contiene una copia de las diapositivas de la plantilla para cada conjunto de datos, en el orden de la fuente de datos.

### ¿Puedo usar una fuente de datos sin guardarla en un archivo?

Sí. Puede crear un `MailMergeDataSource` en código, añadir conjuntos de datos y rellenar campos usando `AddText`. Esto es útil cuando sus datos ya están disponibles en su aplicación.

### ¿La combinación de correspondencia detecta el formato de los datos a partir de la extensión del archivo?

No. El formato de los datos se detecta a partir del contenido, por lo que una fuente de datos compatible no tiene que usar una extensión de archivo concreta.

### ¿Puedo leer datos de un flujo que no soporta búsqueda?

Sí. La combinación de correspondencia admite flujos que no pueden buscarse.

### ¿Qué ocurre si la fuente de datos está vacía o no contiene conjuntos de datos?

La fuente de datos debe contener al menos un conjunto de datos. Asegúrese de que incluye al menos un registro antes de iniciar la operación de combinación.

### ¿Qué ocurre si la fuente de datos tiene un formato no válido?

Si el contenido no se reconoce como uno de los formatos de datos admitidos, se lanza `NotSupportedException`. Si se reconoce pero está mal formado, se lanza `InvalidDataException`. El mensaje de la excepción incluye información sobre la ubicación del error.

### ¿Puedo usar la presentación generada después de que el controlador devuelva?

La presentación pasada al controlador de `MergeToMultiplePresentations` es propiedad de la combinación de correspondencia y se elimina después de que el controlador devuelva. Guárdala o copie el contenido que necesite dentro del controlador y no la retenga ni la elimine usted mismo.

### ¿El controlador se llama en paralelo?

No. Las presentaciones generadas se procesan secuencialmente, en el hilo del llamador. Sólo una presentación generada se mantiene en memoria a la vez por esta operación.

### ¿Qué ocurre si se produce una excepción dentro del controlador?

La operación de combinación se detiene y la excepción se propaga al llamador sin cambios. Las presentaciones ya procesadas no se ven afectadas y los conjuntos de datos restantes no se procesan.

### ¿Puedo usar valores de campos para generar nombres de archivo de salida?

Sí. El controlador proporciona el conjunto de datos actual a través de sus argumentos. Use `GetText` para obtener campos y crear un nombre de archivo para cada presentación generada. Asegúrese de que los valores sean válidos como nombres de archivo en su entorno objetivo.