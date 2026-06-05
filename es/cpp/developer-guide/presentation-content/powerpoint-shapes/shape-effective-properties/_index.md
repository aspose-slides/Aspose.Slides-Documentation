---
title: Obtener propiedades efectivas de forma de presentaciones en C++
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/cpp/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- conjunto de luces
- bisel de forma
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para C++ calcula y aplica propiedades efectivas de forma para una representación precisa de PowerPoint."
---
## **Visión general**

Este tema explica la diferencia entre **local** y **efectiva** propiedades. Los valores locales son valores que se establecen directamente en un nivel de formato específico, como:

1. Propiedades de porción en una diapositiva.
1. Estilos de texto de forma prototipo en una diapositiva de diseño o maestra, cuando la forma del marco de texto de la porción tiene uno.
1. Configuraciones de texto globales en una presentación.

Los valores locales pueden definirse u omitirse en cualquier nivel. Cuando Aspose.Slides necesita el formato final «tal como se renderiza», resuelve la cadena de herencia y devuelve los valores **efectivos**. Puede obtenerlos llamando al método `GetEffective` sobre el objeto de formato local.

El siguiente ejemplo muestra cómo obtener valores efectivos. Asume que la primera forma en la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) con un marco de texto y al menos una porción.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
Los datos de formato efectivo representan el formato calculado actual después de aplicar la herencia. En la implementación actual, algunos objetos de datos efectivos, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportionformateffectivedata/), pueden almacenarse en caché internamente. Llamar a `GetEffective` de nuevo después de cambiar el formato heredado o del padre puede actualizar la caché, y un objeto obtenido previamente puede ya no representar el estado anterior. Si necesita conservar valores efectivos para reutilizarlos después, copie las propiedades requeridas, como altura de fuente, color de relleno, estilo de fuente o alineación, en su propio objeto de datos.
{{% /alert %}}

## **Obtener propiedades efectivas de una cámara**

Aspose.Slides permite obtener propiedades efectivas de una cámara. La interfaz [ICameraEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/icameraeffectivedata/) representa un objeto inmutable que contiene propiedades de cámara efectivas. Una instancia de [ICameraEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/icameraeffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas de la cámara. Asume que la primera forma en la primera diapositiva tiene formato 3D.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **Obtener propiedades efectivas de un conjunto de luces**

Aspose.Slides permite obtener propiedades efectivas de un conjunto de luces. La interfaz [ILightRigEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilightrigeffectivedata/) representa un objeto inmutable que contiene propiedades de conjunto de luces efectivas. Una instancia de [ILightRigEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilightrigeffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas del conjunto de luces. Asume que la primera forma en la primera diapositiva tiene formato 3D.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **Obtener propiedades efectivas de un bisel de forma**

Aspose.Slides permite obtener propiedades efectivas de un bisel de forma. La interfaz [IShapeBevelEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapebeveleffectivedata/) representa un objeto inmutable que contiene propiedades de relieve de caras efectivas para una forma. Una instancia de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapebeveleffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformateffectivedata/), que proporciona valores efectivos para [IThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/).

El siguiente fragmento de código muestra cómo obtener propiedades efectivas del bisel superior de una forma. Asume que la primera forma en la primera diapositiva tiene formato 3D.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **Obtener propiedades efectivas de un marco de texto**

Con Aspose.Slides, puede obtener propiedades efectivas de un marco de texto. La interfaz [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformateffectivedata/) contiene propiedades efectivas de formato de marco de texto.

El siguiente fragmento de código muestra cómo obtener propiedades de formato de marco de texto efectivas. Asume que la primera forma en la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) con un marco de texto.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **Obtener propiedades efectivas de un estilo de texto**

Con Aspose.Slides, puede obtener propiedades efectivas de un estilo de texto. La interfaz [ITextStyleEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextstyleeffectivedata/) contiene propiedades efectivas de estilo de texto.

El siguiente fragmento de código muestra cómo obtener propiedades de estilo de texto efectivas. Asume que la primera forma en la primera diapositiva es un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) con un marco de texto.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **Obtener el valor efectivo de la altura de fuente**

Con Aspose.Slides, puede obtener la altura de fuente efectiva. El siguiente código demuestra cómo cambia la altura de fuente efectiva de una porción después de establecer valores locales de altura de fuente en diferentes niveles de la estructura de la presentación.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Obtener el formato de relleno efectivo de una tabla**

Con Aspose.Slides, puede obtener el formato de relleno efectivo para distintas partes de una tabla. La interfaz [IFillFormatEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifillformateffectivedata/) contiene propiedades efectivas de formato de relleno. El formato de celda tiene mayor prioridad que el formato de fila, el formato de fila tiene mayor prioridad que el formato de columna y el formato de columna tiene mayor prioridad que el formato de toda la tabla.

Como resultado, se utilizan las propiedades de [ICellFormatEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/icellformateffectivedata/) para dibujar la celda de la tabla. El siguiente fragmento de código muestra cómo obtener el formato de relleno efectivo para distintas partes de la tabla. Asume que la primera forma en la primera diapositiva es un [ITable](https://reference.aspose.com/slides/es/cpp/aspose.slides/itable/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **Preguntas frecuentes**

**¿`GetEffective` devuelve una instantánea?**

No siempre. Los datos efectivos representan el formato calculado después de aplicar la herencia, pero algunos objetos de datos efectivos pueden estar almacenados en caché internamente. Una llamada posterior a `GetEffective` puede recalcular el formato y actualizar la caché, por lo que un objeto obtenido previamente no debe considerarse una instantánea duradera.

**¿Cuándo debo volver a leer las propiedades efectivas?**

Llame a `GetEffective` nuevamente después de cambiar el formato local, los estilos padre, el formato de diseño, el formato maestro o los valores predeterminados a nivel de presentación. La próxima llamada vuelve a evaluar la jerarquía de formato y devuelve el resultado efectivo actual.

**¿Cambiar o eliminar una diapositiva de diseño/maestra afecta a las propiedades efectivas ya recuperadas?**

Sí, pero el cambio se reflejará en la siguiente llamada a `GetEffective`. Si se modifica o elimina una fuente de formato padre, los datos efectivos obtenidos previamente pueden quedar obsoletos. Una vez llamado de nuevo a `GetEffective`, Aspose.Slides reevalúa el árbol de formato y los valores resultantes de fuentes, colores, tamaños u otros pueden cambiar.

**¿Puedo modificar valores a través de los objetos de datos efectivos?**

No. Los objetos de datos efectivos exponen valores calculados. Realice los cambios en los objetos de formato local y luego vuelva a obtener los valores efectivos.

**¿Qué ocurre si una propiedad no está establecida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**

El valor efectivo se determina mediante el mecanismo predeterminado, que incluye los valores por defecto de PowerPoint y Aspose.Slides. Ese valor resuelto pasa a formar parte de los datos efectivos actuales.

**A partir de un valor de fuente efectivo, ¿puedo saber qué nivel proporcionó el tamaño o la tipografía?**

No directamente. Los datos efectivos devuelven el valor final. Para encontrar la fuente, revise los valores locales en la porción, párrafo, marco de texto y estilos de texto en los niveles de diseño, maestro y presentación hasta encontrar la primera definición explícita.

**¿Por qué a veces los valores efectivos parecen idénticos a los locales?**

Porque el valor local resultó ser el final (no fue necesaria una herencia de nivel superior). En esos casos, el valor efectivo coincide con el local.

**¿Cuándo debo usar propiedades efectivas y cuándo trabajar solo con las locales?**

Use los datos efectivos cuando necesite el resultado «tal como se renderiza» tras aplicar toda la herencia, por ejemplo, para alinear colores, sangrías o tamaños. Si necesita conservar esos valores independientemente de cambios posteriores de formato, copie las propiedades requeridas en su propio objeto. Si necesita modificar el formato en un nivel específico, altere las propiedades locales y, si es necesario, vuelva a leer los datos efectivos para verificar el resultado.