---
title: Redimensionar Formas en la Diapositiva
type: docs
weight: 100
url: /es/cpp/re-sizing-shapes-on-slide/
---

#### **Redimensionar Formas en la Diapositiva**
Una de las preguntas más frecuentes que hacen los clientes de Aspose.Slides para C++ es cómo redimensionar formas para que cuando se cambie el tamaño de la diapositiva, los datos no se corten. Este breve consejo técnico muestra cómo lograr eso. 

Para evitar la desorientación de las formas, cada forma en la diapositiva necesita ser actualizada de acuerdo con el nuevo tamaño de la diapositiva.

``` cpp
// Cargar una presentación
SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"D:\\TestResize.ppt");

// Tamaño de diapositiva antiguo
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Cambiar el tamaño de la diapositiva
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Nuevo tamaño de la diapositiva
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        // Redimensionar posición
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // Redimensionar el tamaño de la forma si es necesario 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
    }
}

presentation->Save(u"Resize.pptx", Export::SaveFormat::Pptx);
```

{{% alert color="primary" %}}

Si hay alguna tabla en la diapositiva, entonces el código anterior no funcionaría de manera perfecta. En ese caso, cada celda de la tabla necesita ser redimensionada.

{{% /alert %}}

Necesitas usar el siguiente código de tu parte si necesitas redimensionar las diapositivas con tablas. Establecer el ancho o la altura de la tabla es un caso especial en las formas donde necesitas alterar la altura individual de las filas y el ancho de las columnas para alterar la altura y el ancho de la tabla.

``` cpp
SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"D:\\Test.pptx");

// Tamaño de diapositiva antiguo
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Cambiar el tamaño de la diapositiva
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Nuevo tamaño de la diapositiva
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

for (auto master : presentation->get_Masters())
{
    for (auto shape : master->get_Shapes())
    {
        // Redimensionar posición
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // Redimensionar el tamaño de la forma si es necesario 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
    }

    for (auto layoutslide : master->get_LayoutSlides())
    {
        for (auto shape : layoutslide->get_Shapes())
        {
            //Redimensionar posición
            shape->set_Height(shape->get_Height() * ratioHeight);
            shape->set_Width(shape->get_Width() * ratioWidth);

            //Redimensionar el tamaño de la forma si es necesario 
            shape->set_Y(shape->get_Y() * ratioHeight);
            shape->set_X(shape->get_X() * ratioWidth);
        }
    }
}

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        // Redimensionar posición
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // Redimensionar el tamaño de la forma si es necesario 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = System::ExplicitCast<ITable>(shape);
            for (auto row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * ratioHeight);
                //   row.Height = row.Height * ratioHeight;
            }
            for (auto col : table->get_Columns())
            {
                col->set_Width(col->get_Width() * ratioWidth);
            }
        }
    }
}

presentation->Save(u"D:\\Resize.pptx", Export::SaveFormat::Pptx);
```