---
title: Formateo de Texto
type: docs
weight: 50
url: /cpp/text-formatting/
keywords:
- resaltar texto
- expresión regular
- alinear párrafos de texto
- transparencia del texto
- propiedades de la fuente del párrafo
- familia de fuentes
- rotación de texto
- rotación de ángulo personalizado
- marco de texto
- espaciado de líneas
- propiedad de ajuste automático
- ancla de marco de texto
- tabulación de texto
- estilo de texto predeterminado
- C++
- Aspose.Slides para .C++
description: "Gestionar y manipular propiedades de texto y marco de texto en C++"
---

## **Resaltar Texto**
Se ha agregado un nuevo método HighlightText a las clases ITextFrame y TextFrame. Permite resaltar una parte del texto con color de fondo utilizando una muestra de texto, similar a la herramienta de Color de Resalte de Texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta función:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 

Aspose proporciona un servicio de edición de PowerPoint en línea, [gratuito](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Resaltar Texto utilizando Expresión Regular**
Se ha agregado un nuevo método HighlightRegex a las clases ITextFrame y TextFrame. Permite resaltar una parte del texto con color de fondo utilizando regex, similar a la herramienta de Color de Resalte de Texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta función:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **Establecer Color de Fondo del Texto**

Aspose.Slides te permite especificar tu color preferido para el fondo de un texto.

Este código C++ te muestra cómo establecer el color de fondo para un texto completo:

```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Negro");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Rojo ");

    auto portion3 = System::MakeObject<Portion>(u"Negro");
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

Este código C++ te muestra cómo establecer el color de fondo solo para una porción de un texto:

```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Negro");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Rojo ");

    auto portion3 = System::MakeObject<Portion>(u"Negro");
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
        return portion->get_Text().Contains(u"Rojo");
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

## **Alinear Párrafos de Texto**
El formateo de texto es uno de los elementos clave al crear cualquier tipo de documentos o presentaciones. Sabemos que Aspose.Slides para C++ admite agregar texto a las diapositivas, pero en este tema, veremos cómo podemos controlar la alineación de los párrafos de texto en una diapositiva. Por favor, sigue los pasos a continuación para alinear párrafos de texto utilizando Aspose.Slides para C++ :

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtén la referencia de una diapositiva usando su índice.
3. Accede a las formas de marcador de posición presentes en la diapositiva y conviértelas a AutoShape.
4. Obtén el párrafo (que necesita ser alineado) del TextFrame expuesto por AutoShape.
5. Alinea el párrafo. Un párrafo puede ser alineado a la derecha, izquierda, centrado y justificado.
6. Escribe la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se da a continuación.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **Establecer Transparencia para el Texto**
Este artículo demuestra cómo establecer la propiedad de transparencia a cualquier forma de texto utilizando Aspose.Slides. Para establecer la transparencia en el texto. Por favor, sigue los pasos a continuación:

1. Crea una instancia de la clase Presentation.
2. Obtén la referencia de una diapositiva.
3. Establece el color de sombra.
4. Escribe la presentación como un archivo PPTX.

La implementación de los pasos anteriores se da a continuación.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **Establecer Espaciado de Caracteres para el Texto**

Aspose.Slides te permite establecer el espacio entre letras en un cuadro de texto. De esta manera, puedes ajustar la densidad visual de una línea o bloque de texto expandiendo o condensando el espacio entre caracteres.

Este código C++ te muestra cómo expandir el espaciado para una línea de texto y condensar el espaciado para otra línea:

```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // expand
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // condense

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Gestionar las Propiedades de la Fuente del Párrafo**

Las presentaciones generalmente contienen tanto texto como imágenes. El texto se puede formatear de varias maneras, ya sea para resaltar secciones y palabras específicas o para adaptarse a los estilos corporativos. El formateo de texto ayuda a los usuarios a variar el aspecto del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides para C++ para configurar las propiedades de la fuente de los párrafos de texto en las diapositivas. Para gestionar las propiedades de la fuente de un párrafo utilizando Aspose.Slides para C++ :

1. Crea una instancia de la clase `Presentation`.
1. Obtén la referencia de una diapositiva utilizando su índice.
1. Accede a las formas de marcador de posición en la diapositiva y conviértelas a AutoShape.
1. Obtén el párrafo del TextFrame expuesto por AutoShape.
1. Justifica el párrafo.
1. Accede a la porción de texto del párrafo.
1. Define la fuente utilizando FontData y establece la fuente de la porción de texto en consecuencia.
   1. Establece la fuente en negrita.
   1. Establece la fuente en cursiva.
1. Establecer el color de la fuente utilizando el FillFormat expuesto por el objeto de la Porción.
1. Escribe la presentación modificada en un archivo PPTX.

La implementación de los pasos anteriores se da a continuación. Toma una presentación sencilla y formatea las fuentes en una de las diapositivas.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}


## **Gestionar la Familia de Fuentes del Texto**
Una porción se utiliza para contener texto con un estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides para C++ para crear un cuadro de texto con algo de texto y luego definir una fuente particular y varias otras propiedades de la categoría de la familia de fuentes. Para crear un cuadro de texto y establecer las propiedades de la fuente del texto en él:

1. Crea una instancia de la clase `Presentation`.
2. Obtén la referencia de una diapositiva utilizando su índice.
3. Agrega un AutoShape de tipo Rectángulo a la diapositiva.
4. Elimina el estilo de relleno asociado con el AutoShape.
5. Accede al TextFrame del AutoShape.
6. Agrega algo de texto al TextFrame.
7. Accede al objeto Porción asociado con el TextFrame.
8. Define la fuente que se utilizará para la Porción.
9. Establece otras propiedades de la fuente como negrita, cursiva, subrayado, color y altura utilizando las propiedades relevantes expuestas por el objeto Porción.
10. Escribe la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se da a continuación.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **Establecer Tamaño de Fuente para el Texto**

Aspose.Slides te permite elegir tu tamaño de fuente preferido para el texto existente en un párrafo y otros textos que puedan agregarse al párrafo más adelante.

Este código C++ te muestra cómo establecer el tamaño de fuente para textos contenidos en un párrafo:

```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Obtiene la primera forma, por ejemplo.
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // Obtiene el primer párrafo, por ejemplo.
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // Establece el tamaño de fuente predeterminado a 20 pt para todos los textos en el párrafo.
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // Establece el tamaño de fuente a 20 pt para los textos actuales en el párrafo.
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Establecer Rotación de Texto**

Aspose.Slides para C++ permite a los desarrolladores rotar el texto. El texto se puede configurar para aparecer como Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical o WordArtVerticalRightToLeft. Para rotar el texto de cualquier TextFrame, sigue los pasos a continuación:

1. Crea una instancia de la clase `Presentation`.
2. Accede a la primera diapositiva.
3. Agrega cualquier forma a la diapositiva.
4. Accede al TextFrame.
5. Rota el texto.
6. Guarda el archivo en el disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}


## **Tabs y EffectiveTabs en la Presentación**
- EffectiveTabs.ExplicitTabCount (2 en nuestro caso) propiedad es igual a Tabs.Count.
- La colección EffectiveTabs incluye todos los tabs (de la colección Tabs y de los tabs predeterminados)
- EffectiveTabs.ExplicitTabCount (2 en nuestro caso) propiedad es igual a Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) propiedad muestra la distancia entre los tabs predeterminados (3 y 4 en nuestro ejemplo).
- EffectiveTabs.GetTabByIndex(index) con index = 0 devolverá el primer tab explícito (Posición = 731), index = 1 - segundo tab (Posición = 1241). Si intentas obtener el siguiente tab con index = 2, devolverá el primer tab predeterminado (Posición = 1470), etc.
- EffectiveTabs.GetTabAfterPosition(pos) se utiliza para obtener la siguiente tabulación después de algún texto. Por ejemplo, tienes el texto: "Helloworld!". Para renderizar tal texto, deberías saber dónde comenzar a dibujar "world!". Primero, deberías calcular la longitud de "Hello" en píxeles y llamar a GetTabAfterPosition con este valor. Obtendrás la siguiente posición de tabulación para dibujar "world!".

## **Espaciado de Líneas del Párrafo**

Aspose.Slides proporciona propiedades bajo `ParagraphFormat`—`SpaceAfter`, `SpaceBefore` y `SpaceWithin`—que permiten gestionar el espaciado de líneas para un párrafo. Las tres propiedades se utilizan de esta manera:

* Para especificar el espaciado de líneas para un párrafo en porcentaje, usa un valor positivo. 
* Para especificar el espaciado de líneas para un párrafo en puntos, usa un valor negativo.

Por ejemplo, puedes aplicar un espaciado de 16pt para un párrafo estableciendo la propiedad `SpaceBefore` en -16.

Así es como puedes especificar el espaciado de líneas para un párrafo específico:

1. Carga una presentación que contenga un AutoShape con algo de texto en él.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Accede al TextFrame.
4. Accede al Párrafo.
5. Establece las propiedades del Párrafo.
6. Guarda la presentación.

Este código C++ te muestra cómo especificar el espaciado de líneas para un párrafo:

``` cpp
// La ruta al directorio de documentos.
System::String dataDir = GetDataPath();

// Crea una instancia de la clase Presentation
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// Obtén la referencia de una diapositiva por su índice
auto sld = presentation->get_Slides()->idx_get(0);

// Accede al TextFrame
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// Accede al Párrafo
auto para = tf1->get_Paragraphs()->idx_get(0);

// Establece propiedades del Párrafo
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// Guarda la Presentación
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```


## **Establecer la Propiedad AutofitType del Marco de Texto**
En este tema, exploraremos las diferentes propiedades de formato del marco de texto. Este artículo cubre cómo establecer la propiedad AutofitType del marco de texto, el ancla del texto y la rotación del texto en la presentación. Aspose.Slides para C++ permite a los desarrolladores establecer la propiedad AutofitType de cualquier marco de texto. AutofitType podría establecerse en Normal o Forma. Si se establece en Normal, la forma permanecerá igual, mientras que el texto se ajustará sin causar que la forma cambie, mientras que si AutofitType se establece en forma, entonces la forma se modificará de manera que solo el texto requerido esté contenido en ella. Para establecer la propiedad AutofitType de un marco de texto, sigue los pasos a continuación:

1. Crea una instancia de la clase Presentation.
2. Accede a la primera diapositiva.
3. Agrega cualquier forma a la diapositiva.
4. Accede al TextFrame.
5. Establece el AutofitType del TextFrame.
6. Guarda el archivo en el disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}


## **Establecer Ancla de TextFrame**
Aspose.Slides para C++ permite a los desarrolladores anclar cualquier TextFrame. TextAnchorType especifica dónde se coloca ese texto en la forma. TextAnchorType podría establecerse en Superior, Centro, Inferior, Justificado o Distribuido. Para establecer el ancla de cualquier TextFrame, sigue los pasos a continuación:

1. Crea una instancia de la clase `Presentation`.
2. Accede a la primera diapositiva.
3. Agrega cualquier forma a la diapositiva.
4. Accede al TextFrame.
5. Establece TextAnchorType del TextFrame.
6. Guarda el archivo en el disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}


## **Establecer Ángulo de Rotación Personalizado para TextFrame**
Aspose.Slides para C++ ahora admite establecer el ángulo de rotación personalizado para el marco de texto. En este tema, veremos con un ejemplo cómo establecer la propiedad RotationAngle en Aspose.Slides. La nueva propiedad RotationAngle se ha agregado a las interfaces IChartTextBlockFormat e ITextFrameFormat, lo que permite establecer el ángulo de rotación personalizado para el marco de texto. Para establecer la propiedad RotationAngle, sigue los pasos a continuación:

1. Crea una instancia de la clase Presentation.
2. Agrega un gráfico a la diapositiva.
3. Establece la propiedad RotationAngle.
4. Escribe la presentación como un archivo PPTX.

En el ejemplo que se da a continuación, establecemos la propiedad RotationAngle.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **Establecer Idioma de Prueba**

Aspose.Slides proporciona la propiedad [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (expuesta por la clase [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)) para permitirte establecer el idioma de prueba para un documento de PowerPoint. El idioma de prueba es el idioma por el cual se revisan las ortografías y la gramática en PowerPoint.

Este código C++ te muestra cómo establecer el idioma de prueba para un PowerPoint:

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
// establece el Id de un idioma de prueba

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Establecer Idioma Predeterminado**

Este código C++ te muestra cómo establecer el idioma predeterminado para toda una presentación de PowerPoint:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Agrega una nueva forma rectangular con texto
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"Nuevo Texto");

// Verifica el idioma de la primera porción
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Establecer Estilo de Texto Predeterminado**

Si necesitas aplicar el mismo formato de texto predeterminado a todos los elementos de texto de una presentación de una vez, puedes usar el método `get_DefaultTextStyle` de la interfaz [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) y establecer el formato preferido. El siguiente ejemplo de código muestra cómo establecer la fuente en negrita predeterminada (14 pt) para el texto en todas las diapositivas en una nueva presentación.

```c++
auto presentation = MakeObject<Presentation>();

// Obtener el formato de párrafo de nivel superior.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```