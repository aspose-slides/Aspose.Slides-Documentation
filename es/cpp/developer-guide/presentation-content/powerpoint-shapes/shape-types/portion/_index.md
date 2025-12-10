---
title: Administrar porciones de texto en presentaciones usando C++
linktitle: Porción de texto
type: docs
weight: 70
url: /es/cpp/portion/
keywords:
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo gestionar porciones de texto en presentaciones de PowerPoint usando Aspose.Slides para C++, mejorando el rendimiento y la personalización."
---

## **Obtener coordenadas de una porción de texto**
**GetCoordinates()** method ha sido añadido a IPortion y a la clase Portion, lo que permite recuperar las coordenadas del inicio de la porción:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```


## **FAQ**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un mismo párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/cpp/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué sobrescribe una Portion y qué se toma del Paragraph/TextFrame?**

Las propiedades a nivel de Portion tienen la mayor precedencia. Si una propiedad no está establecida en el [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/), el motor la toma del [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/); si tampoco está establecida allí, la toma del [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) o del estilo del [theme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/theme/).

**¿Qué ocurre si la fuente especificada para una Portion no está disponible en la máquina/servidor de destino?**

Se aplican las [reglas de sustitución de fuentes](/slides/es/cpp/font-selection-sequence/). El texto puede refluirse: métricas, guionado y ancho pueden cambiar, lo que afecta a la posición precisa.

**¿Puedo establecer una transparencia o degradado de relleno de texto específico para una Portion, independiente del resto del párrafo?**

Sí, el color, relleno y transparencia del texto a nivel del [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) pueden diferir de los fragmentos vecinos.