---
title: Incrustar fuentes en presentaciones usando C++
linktitle: Incrustación de fuente
type: docs
weight: 40
url: /es/cpp/embedded-font/
keywords:
- añadir fuente
- incrustar fuente
- incrustación de fuentes
- obtener fuente incrustada
- añadir fuente incrustada
- eliminar fuente incrustada
- comprimir fuente incrustada
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Incrusta fuentes TrueType en presentaciones PowerPoint y OpenDocument con Aspose.Slides para C++, garantizando una renderización precisa en todas las plataformas."
---
## **Introducción**

**Fuentes incrustadas en PowerPoint** ayudan a garantizar que su presentación mantenga su apariencia prevista cuando se abre en cualquier sistema o dispositivo. Esto es especialmente importante al usar fuentes personalizadas, de terceros o no estándar para la marca o fines creativos. Sin fuentes incrustadas, el texto puede ser sustituido, los diseños pueden romperse y los caracteres pueden aparecer como símbolos o rectángulos ilegibles, comprometiendo el diseño general.

Aspose.Slides for C++ proporciona un conjunto de potentes API para gestionar fuentes incrustadas mediante código. Puede usar las clases [FontsManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/) y [FontData](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontdata/) para inspeccionar, añadir o eliminar fuentes incrustadas en los archivos de su presentación. Además, la clase [Compress](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/) le permite optimizar el tamaño del archivo comprimiendo los datos de fuentes sin afectar la calidad ni la apariencia.

Estas herramientas le brindan un control total sobre la incrustación de fuentes, ayudándole a mantener una tipografía coherente en todas las plataformas mientras reduce el tamaño del archivo cuando sea necesario.

## **Obtener fuentes incrustadas de una presentación**

Aspose.Slides for C++ proporciona el método `GetEmbeddedFonts` a través de la clase [FontsManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/), que le permite obtener una lista de fuentes incrustadas en una presentación de PowerPoint. Esto puede ser útil para auditar el uso de fuentes, garantizar el cumplimiento de las directrices de marca o verificar que todas las fuentes necesarias estén correctamente incluidas antes de compartir el archivo.

El siguiente código C++ muestra cómo obtener fuentes incrustadas de un archivo de presentación:

```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Obtener todas las fuentes incrustadas.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Imprimir nombres de las fuentes incrustadas.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Añadir fuentes incrustadas a una presentación**

Aspose.Slides for C++ le permite incrustar fuentes en una presentación de PowerPoint mediante el método [AddEmbeddedFont](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/addembeddedfont/), que incluye dos sobrecargas para un uso flexible. Puede controlar cuánto de la fuente se incrusta usando la enumeración [EmbedFontCharacters](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/embedfontcharacters/) — por ejemplo, eligiendo incrustar solo los caracteres utilizados o todo el conjunto de la fuente. Esta característica es especialmente útil al preparar una presentación para compartir o distribuir, garantizando que las fuentes personalizadas o no estándar se muestren correctamente en todos los sistemas, incluso si esas fuentes no están instaladas.

El siguiente código C++ verifica todas las fuentes usadas en una presentación e incrusta cualquier fuente que aún no esté incrustada.

```cpp
// Cargar un archivo de presentación.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Comprobar si la fuente ya está incrustada.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Incrustar la fuente en la presentación.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Guardar la presentación en disco.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Eliminar fuentes incrustadas de una presentación**

Aspose.Slides for C++ proporciona el método `RemoveEmbeddedFont` a través de la clase [FontsManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/), que le permite eliminar fuentes específicas incrustadas en una presentación de PowerPoint. Esto puede ayudar a reducir el tamaño total del archivo, especialmente si las fuentes incrustadas ya no se usan o no son necesarias. Eliminar fuentes no utilizadas también puede mejorar el rendimiento y garantizar que su presentación incluya solo los recursos esenciales.

El siguiente código C++ muestra cómo eliminar una fuente incrustada de una presentación:

```cpp
auto fontName = u"Calibri";

// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Obtener todas las fuentes incrustadas.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Eliminar la fuente incrustada.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Comprimir fuentes incrustadas**

Aspose.Slides for C++ proporciona el método `CompressEmbeddedFonts` a través de la clase [Compress](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/), lo que le permite reducir el tamaño total del archivo de una presentación optimizando los datos de fuentes incrustadas. Esto es especialmente útil cuando su presentación incluye fuentes grandes o múltiples, y desea mantener el archivo ligero para compartir, almacenar o usar en línea, sin comprometer la fidelidad visual del contenido.

El siguiente código C++ muestra cómo comprimir fuentes incrustadas en una presentación de PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Preguntas frecuentes**

**¿Cómo puedo saber si una fuente específica en la presentación seguirá siendo sustituida durante la renderización a pesar de estar incrustada?**

Consulte la [información de sustitución](/slides/es/cpp/font-substitution/) en el gestor de fuentes y las [reglas de reserva/sustitución](/slides/es/cpp/fallback-font/): si la fuente no está disponible o está restringida, se usará una fuente de reserva.

**¿Vale la pena incrustar fuentes "del sistema" como Arial/Calibri?**

Normalmente no, ya que casi siempre están disponibles. Pero para una portabilidad total en entornos "delgados" (Docker, un servidor Linux sin fuentes preinstaladas), incrustar fuentes del sistema puede eliminar el riesgo de sustituciones inesperadas.