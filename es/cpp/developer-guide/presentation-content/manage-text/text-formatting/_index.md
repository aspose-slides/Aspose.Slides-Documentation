---
title: Formatear texto de PowerPoint en C++
linktitle: Formateo de texto
type: docs
weight: 50
url: /es/cpp/text-formatting/
keywords:
- resaltar texto
- expresión regular
- alinear párrafo
- estilo de texto
- fondo de texto
- transparencia de texto
- espaciado de caracteres
- propiedades de fuente
- familia de fuente
- rotación de texto
- ángulo de rotación
- marco de texto
- interlineado
- propiedad autofit
- ancla del marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Formatear y dar estilo al texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para C++. Personalizar fuentes, colores, alineación y más."
---

## **Resaltar texto**
Se ha añadido el nuevo método HighlightText a las clases ITextFrame y TextFrame. Permite resaltar una parte del texto con un color de fondo usando una muestra de texto, similar a la herramienta de Color de resaltado de texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta función:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 

Aspose ofrece un sencillo, [servicio gratuito de edición de PowerPoint en línea](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Resaltar texto usando expresiones regulares**
Se ha añadido el nuevo método HighlightRegex a las clases ITextFrame y TextFrame. Permite resaltar una parte del texto con un color de fondo usando expresiones regulares, similar a la herramienta de Color de resaltado de texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta función:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **Establecer color de fondo del texto**

Aspose.Slides le permite especificar el color preferido para el fondo de un texto.

Este código C++ muestra cómo establecer el color de fondo para todo un texto:
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));
    auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    for (auto&& portion : portions)
    {
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Blue());
    }
    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```


Este código C++ muestra cómo establecer el color de fondo solo para una parte del texto:
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));

	auto predicate = [](System::SharedPtr<IPortion> portion) -> bool {
        return portion->get_Text().Contains(u"Red");
	};

	auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    System::SharedPtr<IPortion> redPortion;
	for (auto&& portion : portions)
        if (predicate(portion))
            redPortion = portion;

    redPortion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Red());

    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```


## **Alinear párrafos de texto**
El formato de texto es uno de los elementos clave al crear cualquier tipo de documentos o presentaciones. Sabemos que Aspose.Slides para C++ admite la inserción de texto en diapositivas, pero en este tema veremos cómo controlar la alineación de los párrafos de texto en una diapositiva. Siga los pasos a continuación para alinear los párrafos de texto usando Aspose.Slides para C++ :

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva utilizando su índice.
3. Acceda a las formas Placeholder presentes en la diapositiva y conviértalas a AutoShape.
4. Obtenga el párrafo (que necesita alinearse) del TextFrame expuesto por AutoShape.
5. Alinee el párrafo. Un párrafo puede alinearse a la derecha, izquierda, centro y justificado.
6. Guarde la presentación modificada como archivo PPTX.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **Establecer transparencia para el texto**
Este artículo muestra cómo establecer la propiedad de transparencia para cualquier forma de texto usando Aspose.Slides. Para establecer la transparencia del texto, siga los pasos a continuación:

1. Cree una instancia de la clase Presentation.
2. Obtenga la referencia de una diapositiva.
3. Establezca el color de la sombra
4. Guarde la presentación como archivo PPTX.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **Establecer espaciado de caracteres para el texto**
Aspose.Slides le permite establecer el espacio entre letras en un cuadro de texto. De esta forma, puede ajustar la densidad visual de una línea o bloque de texto ampliando o condensando el espaciado entre caracteres.

Este código C++ muestra cómo expandir el espaciado para una línea de texto y condensar el espaciado para otra línea:
```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // expandir
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // condensar

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```


## **Administrar propiedades de fuente del texto**

Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas o para cumplir con los estilos corporativos. El formato de texto ayuda a los usuarios a variar la apariencia del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides para C++ para configurar las propiedades de fuente de los párrafos de texto en diapositivas. Para administrar las propiedades de fuente de un párrafo usando Aspose.Slides para C++ :

1. Crea una instancia de la clase `Presentation`.
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Acceda a las formas Placeholder en la diapositiva y conviértalas a AutoShape.
4. Obtenga el párrafo del TextFrame expuesto por AutoShape.
5. Justifique el párrafo.
6. Acceda a la Porción de texto del párrafo.
7. Defina la fuente usando FontData y establezca la Font de la Porción de texto en consecuencia.
   1. Establezca la fuente en negrita.
   2. Establezca la fuente en cursiva.
8. Establezca el color de la fuente usando FillFormat expuesto por el objeto Portion.
9. Guarde la presentación modificada en un archivo PPTX.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}

## **Administrar familia de fuentes del texto**
Una portion se usa para contener texto con un estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides para C++ para crear un cuadro de texto con algún texto y luego definir una fuente concreta, y varias otras propiedades de la categoría de familia de fuentes. Para crear un cuadro de texto y establecer propiedades de fuente del texto en él:

1. Crea una instancia de la clase `Presentation`.
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un AutoShape del tipo Rectángulo a la diapositiva.
4. Elimine el estilo de relleno asociado al AutoShape.
5. Acceda al TextFrame del AutoShape.
6. Añada texto al TextFrame.
7. Acceda al objeto Portion asociado al TextFrame.
8. Defina la fuente a usar para la Portion.
9. Establezca otras propiedades de la fuente como negrita, cursiva, subrayado, color y tamaño usando las propiedades relevantes expuestas por el objeto Portion.
10. Guarde la presentación modificada como archivo PPTX.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **Establecer el tamaño de fuente para el texto**
Aspose.Slides le permite elegir el tamaño de fuente preferido para el texto existente en un párrafo y otros textos que puedan añadirse al párrafo más adelante.

Este código C++ muestra cómo establecer el tamaño de fuente para los textos contenidos en un párrafo:
```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Obtiene la primera forma, por ejemplo.
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // Obtiene el primer párrafo, por ejemplo.
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // Establece el tamaño de fuente predeterminado a 20 pt para todas las porciones de texto en el párrafo.
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // Establece el tamaño de fuente a 20 pt para las porciones de texto actuales en el párrafo.
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Establecer rotación del texto**
Aspose.Slides para C++ permite a los desarrolladores rotar el texto. El texto puede configurarse para aparecer como Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical o WordArtVerticalRightToLeft. Para rotar el texto de cualquier TextFrame, siga los pasos a continuación:

1. Crea una instancia de la clase `Presentation`.
2. Acceda a la primera diapositiva.
3. Añada cualquier forma a la diapositiva.
4. Acceda al TextFrame.
5. Rote el texto.
6. Guarde el archivo en disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}

## **Pestañas y pestañas efectivas en una presentación**
- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- La colección EffectiveTabs incluye todas las pestañas (de la colección Tabs y las pestañas predeterminadas).
- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- La propiedad EffectiveTabs.DefaultTabSize (294) muestra la distancia entre las pestañas predeterminadas (3 y 4 en nuestro ejemplo).
- EffectiveTabs.GetTabByIndex(index) con index = 0 devolverá la primera pestaña explícita (Position = 731), index = 1 la segunda pestaña (Position = 1241). Si intentas obtener la siguiente pestaña con index = 2 devolverá la primera pestaña predeterminada (Position = 1470) y así sucesivamente.
- EffectiveTabs.GetTabAfterPosition(pos) se usa para obtener la siguiente tabulación después de algún texto. Por ejemplo, tienes el texto: "Helloworld!". Para renderizar ese texto debes saber dónde comenzar a dibujar "world!". Primero, calcula la longitud de "Hello" en píxeles y llama a GetTabAfterPosition con ese valor. Obtendrás la posición de la siguiente tabulación para dibujar "world!".

## **Interlineado de un párrafo**
Aspose.Slides proporciona propiedades bajo `ParagraphFormat`—`SpaceAfter`, `SpaceBefore` y `SpaceWithin`—que le permiten gestionar el interlineado de un párrafo. Las tres propiedades se usan de la siguiente manera:

* Para especificar el interlineado de un párrafo en porcentaje, use un valor positivo. 
* Para especificar el interlineado de un párrafo en puntos, use un valor negativo.

Por ejemplo, puedes aplicar un interlineado de 16 pt a un párrafo configurando la propiedad `SpaceBefore` a -16.

1. Cargue una presentación que contenga un AutoShape con texto.
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Acceda al TextFrame.
4. Acceda al párrafo.
5. Establezca las propiedades del párrafo.
6. Guarde la presentación.

``` cpp
// La ruta al directorio de documentos.
System::String dataDir = GetDataPath();

// Crear una instancia de la clase Presentation
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// Obtener la referencia de una diapositiva por su índice
auto sld = presentation->get_Slides()->idx_get(0);

// Acceder al TextFrame
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// Acceder al párrafo
auto para = tf1->get_Paragraphs()->idx_get(0);

// Establecer propiedades del párrafo
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// Guardar la presentación
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```


## **Establecer la propiedad AutofitType de un marco de texto**
En este tema exploraremos las diferentes propiedades de formato de un marco de texto. Este artículo cubre cómo establecer la propiedad AutofitType de un marco de texto, el ancla del texto y rotar el texto en la presentación. Aspose.Slides para C++ permite a los desarrolladores establecer la propiedad AutofitType de cualquier marco de texto. AutofitType puede establecerse en Normal o Shape. Si se establece en Normal, la forma permanecerá igual mientras el texto se ajusta sin que la forma cambie; si se establece en Shape, la forma se modificará de modo que solo contenga el texto requerido. Para establecer la propiedad AutofitType de un marco de texto, siga los pasos a continuación:

1. Cree una instancia de la clase Presentation.
2. Acceda a la primera diapositiva.
3. Añada cualquier forma a la diapositiva.
4. Acceda al TextFrame.
5. Establezca el AutofitType del TextFrame.
6. Guarde el archivo en disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}

## **Establecer el ancla de un TextFrame**
Aspose.Slides para C++ permite a los desarrolladores establecer el ancla de cualquier TextFrame. TextAnchorType especifica dónde se coloca el texto dentro de la forma. TextAnchorType puede establecerse en Top, Center, Bottom, Justified o Distributed. Para establecer el ancla de cualquier TextFrame, siga los pasos a continuación:

1. Cree una instancia de `Presentation` class.
2. Acceda a la primera diapositiva.
3. Añada cualquier forma a la diapositiva.
4. Acceda al TextFrame.
5. Establezca TextAnchorType del TextFrame.
6. Guarde el archivo en disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}

## **Establecer el ángulo de rotación personalizado para un TextFrame**
Aspose.Slides para C++ ahora admite la configuración de un ángulo de rotación personalizado para un TextFrame. En este tema veremos con un ejemplo cómo establecer la propiedad RotationAngle en Aspose.Slides. La nueva propiedad RotationAngle se ha añadido a las interfaces IChartTextBlockFormat e ITextFrameFormat, y permite establecer el ángulo de rotación personalizado para un TextFrame. Para establecer la propiedad RotationAngle, siga los pasos a continuación:

1. Cree una instancia de la clase Presentation.
2. Añada un gráfico en la diapositiva.
3. Establezca la propiedad RotationAngle.
4. Guarde la presentación como archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **Establecer idioma de revisión**
Aspose.Slides ofrece la propiedad [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)) para permitirle establecer el idioma de revisión para un documento PowerPoint. El idioma de revisión es el idioma para el cual se verifica la ortografía y gramática en PowerPoint.

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```


## **Establecer idioma predeterminado**
Este código C++ muestra cómo establecer el idioma predeterminado para toda una presentación PowerPoint:
```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Añade una nueva forma rectangular con texto
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Verifica el idioma de la primera porción
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **Establecer estilo de texto predeterminado**
Si necesita aplicar el mismo formato de texto predeterminado a todos los elementos de texto de una presentación de una sola vez, puede usar el método `get_DefaultTextStyle` de la interfaz [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) y establecer el formato preferido. El ejemplo de código a continuación muestra cómo establecer la fuente en negrita predeterminada (14 pt) para el texto de todas las diapositivas en una nueva presentación.
```c++
auto presentation = MakeObject<Presentation>();

// Obtenga el formato de párrafo de nivel superior.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Extraer texto con el efecto de mayúsculas**
En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva aunque originalmente se haya escrito en minúsculas. Cuando recuperas esa porción de texto con Aspose.Slides, la biblioteca devuelve el texto tal como se ingresó. Para manejar esto, verifica [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/)—si indica `All`, simplemente convierte la cadena devuelta a mayúsculas para que tu salida coincida con lo que los usuarios ven en la diapositiva.

Supongamos que tenemos el siguiente cuadro de texto en la primera diapositiva del archivo sample2.pptx.

![El efecto de mayúsculas](all_caps_effect.png)

El ejemplo de código a continuación muestra cómo extraer el texto con el efecto **All Caps** aplicado:
```cpp
auto presentation = MakeObject<Presentation>(u"sample2.pptx");
auto autoShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```


Salida:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **Preguntas frecuentes**

**¿Cómo modificar texto en una tabla en una diapositiva?**

Para modificar texto en una tabla en una diapositiva, necesita usar el objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Puede iterar a través de todas las celdas de la tabla y cambiar el texto de cada celda accediendo a su marco de texto y a las propiedades de formato de párrafo dentro de cada celda.

**¿Cómo aplicar un color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar un color degradado al texto, use el método `get_FillFormat` en [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/). Establezca el formato de relleno a `Gradient`, donde puede definir los colores de inicio y fin del degradado, junto con otras propiedades como dirección y transparencia para crear el efecto degradado en el texto.