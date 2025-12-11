---
title: Especificar fuentes de reserva para presentaciones en С++
linktitle: Fuente de reserva
type: docs
weight: 10
url: /es/cpp/create-fallback-font/
keywords:
- fuente de reserva
- regla de reserva
- aplicar fuente
- reemplazar fuente
- rango Unicode
- glifo perdido
- glifo correcto
- PowerPoint
- OpenDocument
- presentación
- С++
- Aspose.Slides
description: "Domine Aspose.Slides para С++ para establecer fuentes de reserva en archivos PPT, PPTX y ODP, garantizando una visualización de texto consistente en cualquier dispositivo o sistema operativo."
---

## **Reglas de reserva**

Aspose.Slides soporta la interfaz [IFontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule) y la clase [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) para especificar las reglas que se aplican a una fuente de reserva. La clase [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) representa una asociación entre el rango Unicode especificado, utilizado para buscar glifos faltantes, y una lista de fuentes que pueden contener los glifos correctos:
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Usando varias formas puedes agregar la lista de fuentes:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```


También es posible [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#abd87e889a55b4a62174ddd14f1b1476e) la fuente de reserva o [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#a9bac44ca199a76c6cd004146cb02cd79) en un objeto [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) existente.

La [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection) puede usarse para organizar una lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule), cuando se necesita especificar reglas de sustitución de fuentes de reserva para varios rangos Unicode.

{{% alert color="primary" title="Ver también" %}} 
- [Crear colección de fuentes de reserva](/slides/es/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una fuente de reserva, sustitución de fuente y incrustación de fuente?**

Una fuente de reserva se usa solo para los caracteres que faltan en la fuente principal. [Sustitución de fuentes](/slides/es/cpp/font-substitution/) reemplaza toda la fuente especificada por otra fuente. [Incrustación de fuentes](/slides/es/cpp/embedded-font/) empaqueta las fuentes dentro del archivo de salida para que los destinatarios puedan ver el texto tal como se pretende.

**¿Se aplican las fuentes de reserva durante exportaciones como PDF, PNG o SVG, o solo en el renderizado en pantalla?**

Sí. La reserva afecta a todas las [operaciones de renderizado y exportación](/slides/es/cpp/convert-presentation/) donde los caracteres deben dibujarse pero están ausentes en la fuente original.

**¿La configuración de la reserva modifica el archivo de presentación en sí, y la configuración persistirá en aperturas futuras?**

No. Las reglas de reserva son configuraciones de renderizado en tiempo de ejecución en tu código; no se almacenan dentro del .pptx y no aparecerán en PowerPoint.

**¿El sistema operativo (Windows/Linux/macOS) y el conjunto de directorios de fuentes afectan la selección de la reserva?**

Sí. El motor resuelve las fuentes a partir de las carpetas del sistema disponibles y cualquier [ruta adicional](/slides/es/cpp/custom-font/) que proporciones. Si una fuente no está físicamente disponible, una regla que la referencia no podrá aplicarse.

**¿La reserva funciona para WordArt, SmartArt y gráficos?**

Sí. Cuando estos objetos contienen texto, se aplica el mismo mecanismo de sustitución de glifos para renderizar los caracteres faltantes.