---
title: Formato de Formas
type: docs
weight: 20
url: /es/cpp/shape-formatting/
keywords: "Formato de forma, formato de líneas, estilos de unión de formato, relleno de degradado, relleno de patrón, relleno de imagen, relleno de color sólido, rotar formas, efectos de bisel 3d, efecto de rotación 3d, presentación de PowerPoint, C++, Aspose.Slides para C++"
description: "Formato de forma en presentación de PowerPoint en C++"
---

En PowerPoint, puedes agregar formas a las diapositivas. Dado que las formas están compuestas por líneas, puedes formatear las formas modificando o aplicando ciertos efectos a sus líneas constituyentes. Además, puedes formatear las formas especificando configuraciones que determinan cómo se rellenan (el área en ellas).

![formato-forma-powerpoint](formato-forma-powerpoint.png)

**Aspose.Slides para C++** proporciona interfaces y propiedades que te permiten formatear formas en función de las opciones conocidas en PowerPoint.

## **Formato de Líneas**

Usando Aspose.Slides, puedes especificar tu estilo de línea preferido para una forma. Estos pasos describen tal procedimiento:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) a la diapositiva.
4. Establece un color para las líneas de la forma.
5. Establece el ancho para las líneas de la forma.
6. Establece el [estilo de línea](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a837c78839bf6ebb16979455cd1de59e4) para la línea de la forma.
7. Establece el [estilo de guion](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a7eaad354a35a3b567a7327d625be3c6e) para la línea de la forma.
8. Escribe la presentación modificada como un archivo PPTX.

Este código C++ demuestra una operación donde formateamos un rectángulo `AutoShape`:

```cpp
// Instancia una clase de presentación que representa un archivo de presentación
auto pres = MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto slide = pres->get_Slides()->idx_get(0);

// Agrega la autoforma del tipo rectángulo
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Establece el color de relleno para la forma del rectángulo
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_White());

// Aplica algo de formato a las líneas del rectángulo
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Establece el color para la línea del rectángulo
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Escribe el archivo PPTX en el disco
pres->Save(u"RectShpLn_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Formato de Estilos de Unión**
Estas son las 3 opciones de tipo de unión:

* Redondo
* Canteado
* Bisel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (o la esquina de una forma), utiliza la configuración **Redonda**. Sin embargo, si buscas dibujar una forma con ángulos muy agudos, puede que desees seleccionar **Canteado**.

![estilo-unión-powerpoint](estilo-unión-powerpoint.png)

Este código C++ demuestra una operación donde se crearon 3 rectángulos (la imagen de arriba) con las configuraciones de tipo de unión Canteado, Bisel y Redondo:

```cpp
// Instancia una clase de presentación que representa un archivo de presentación
auto pres = MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto slide = pres->get_Slides()->idx_get(0);

// Agrega 3 autoformas rectángulo
SharedPtr<IAutoShape> shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
SharedPtr<IAutoShape> shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
SharedPtr<IAutoShape> shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);

// Establece el color de relleno para la forma del rectángulo
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Establece el ancho de la línea
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Establece el color para la línea del rectángulo
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Establece el Estilo de Unión
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Agrega texto a cada rectángulo
shape1->get_TextFrame()->set_Text(u"Estilo de Unión Canteado");
shape2->get_TextFrame()->set_Text(u"Estilo de Unión Bisel");
shape3->get_TextFrame()->set_Text(u"Estilo de Unión Redondo");

// Escribe el archivo PPTX en Disco
pres->Save(u"RectShpLnJoin_out.pptx", Export::SaveFormat::Pptx);
```

## **Relleno de Degradado**
En PowerPoint, el relleno de degradado es una opción de formato que te permite aplicar una mezcla continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores en una configuración donde un color se desvanece gradualmente y cambia a otro color.

Así es como usas Aspose.Slides para aplicar un relleno de degradado a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) de la forma a `Degradado`.
5. Agrega tus 2 colores preferidos con posiciones definidas utilizando los métodos `Add` expuestos por la colección `GradientStops` asociada con la clase `GradientFormat`.
6. Escribe la presentación modificada como un archivo PPTX.

Este C++ demuestra una operación donde se usó el efecto de relleno de degradado en una elipse:

```cpp
// Instancia una clase de presentación que representa un archivo de presentación
auto pres = MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto slide = pres->get_Slides()->idx_get(0);
    
// Agrega una autoforma elipse
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);

// Aplica el formato de degradado a la elipse
autoShape->get_FillFormat()->set_FillType(FillType::Gradient);
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Establece la dirección del degradado
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Agrega 2 pasos de degradado
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Escribe el archivo PPTX en disco
pres->Save(u"FillShapesGradient_out.pptx", Export::SaveFormat::Pptx);
```

## **Relleno de Patrón**
En PowerPoint, el relleno de patrón es una opción de formato que te permite aplicar un diseño de dos colores compuesto de puntos, rayas, tramas o cuadros a una forma. Además, puedes seleccionar los colores que prefieras para el primer plano y el fondo de tu patrón.

Aspose.Slides proporciona más de 45 estilos predefinidos que se pueden usar para formatear formas y enriquecer presentaciones. Incluso después de elegir un patrón predefinido, todavía puedes especificar los colores que debe contener el patrón.

Así es como usas Aspose.Slides para aplicar un relleno de patrón a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) de la forma a `Patrón`.
5. Establece tu estilo de patrón preferido para la forma.
6. Establece el [Color de Fondo](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#af55b6343b7bd80d0ad95070e96b8766e) para el [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format).
7. Establece el [Color de Primer Plano](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#a4121d8c2233df4b90cbfd6ea4c312cbe) para el [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format).
8. Escribe la presentación modificada como un archivo PPTX.

Este código C++ demuestra una operación donde se utilizó un relleno de patrón para embellecer un rectángulo:

```cpp
// Instancia una clase de presentación que representa un archivo de presentación
auto pres = MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto slide = pres->get_Slides()->idx_get(0);

// Agrega una autoforma rectángulo
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Establece el tipo de relleno a Patrón
autoShape->get_FillFormat()->set_FillType(FillType::Pattern);

// Establece el estilo del patrón
autoShape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Establece los colores de fondo y primer plano del patrón
autoShape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
autoShape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Escribe el archivo PPTX en disco
pres->Save(u"RectShpPatt_out.pptx", Export::SaveFormat::Pptx);
```

## **Relleno de Imagen**
En PowerPoint, el relleno de imagen es una opción de formato que te permite colocar una imagen dentro de una forma. Esencialmente, puedes usar una imagen como fondo de la forma.

Así es como usas Aspose.Slides para rellenar una forma con una imagen:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) de la forma a `Imagen`.
5. Establece el modo de relleno de imagen a Azulejo.
6. Crea un objeto `IPPImage` utilizando la imagen que se usará para rellenar la forma.
7. Establece la propiedad `Picture.Image` del objeto `PictureFillFormat` al `IPPImage` creado recientemente.
8. Escribe la presentación modificada como un archivo PPTX.

Este código C++ te muestra cómo rellenar una forma con una imagen:

```cpp
// Instancia una clase de presentación que representa un archivo de presentación
auto pres = MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto slide = pres->get_Slides()->idx_get(0);

// Agrega una autoforma rectángulo
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Establece el tipo de relleno a Imagen
autoShape->get_FillFormat()->set_FillType(FillType::Picture);

// Establece el modo de relleno de imagen
autoShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Establece la imagen
auto img = Images::FromFile(u"Tulips.jpg");
auto imgx = pres->get_Images()->AddImage(img);
autoShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Escribe el archivo PPTX en disco
pres->Save(u"RectShpPic_out.pptx", Export::SaveFormat::Pptx);
```

## **Relleno de Color Sólido**
En PowerPoint, el relleno de color sólido es una opción de formato que permite rellenar una forma con un solo color. El color elegido es típicamente un color liso. El color se aplica al fondo de la forma con cualquier efecto o modificación especial.

Así es como usas Aspose.Slides para aplicar un relleno de color sólido a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) a la diapositiva.
4. Establece el [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) de la forma a `Sólido`.
5. Establece tu color preferido para la forma.
6. Escribe la presentación modificada como un archivo PPTX.

Los pasos anteriores se implementan en el siguiente ejemplo.

```cpp
// Instancia una clase de presentación que representa un archivo de presentación
auto pres = MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto slide = pres->get_Slides()->idx_get(0);

// Agrega una autoforma rectángulo
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Establece el tipo de relleno a Sólido
autoShape->get_FillFormat()->set_FillType(FillType::Solid);

// Establece el color para el rectángulo
autoShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Escribe el archivo PPTX en disco
pres->Save(u"RectShpSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **Establecer Transparencia**

En PowerPoint, cuando rellenas formas con colores sólidos, degradados, imágenes o texturas, puedes especificar el nivel de transparencia que determina la opacidad de un relleno. De esta manera, por ejemplo, si estableces un bajo nivel de transparencia, el objeto de la diapositiva o el fondo detrás (de la forma) se muestra a través.

Aspose.Slides te permite establecer el nivel de transparencia para una forma de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) a la diapositiva.
4. Usa `Color.FromArgb` con el componente alfa establecido.
5. Guarda el objeto como un archivo de PowerPoint.

Este código C++ demuestra el proceso:

```cpp
// Instancia una clase de presentación que representa un archivo de presentación
auto pres = MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto slide = pres->get_Slides()->idx_get(0);

// Agrega una forma sólida
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);

// Agrega una forma transparente sobre la forma sólida
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(128, 204, 102, 0));
   
// Escribe el archivo PPTX en disco
pres->Save(u"ShapeTransparentOverSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **Rotar Formas**
Aspose.Slides te permite rotar una forma añadida a una diapositiva de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) a la diapositiva.
4. Rota la forma por los grados necesarios.
5. Escribe la presentación modificada como un archivo PPTX.

Este código C++ te muestra cómo rotar una forma 90 grados:

```cpp
// Instancia una clase de presentación que representa un archivo de presentación
auto pres = MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto slide = pres->get_Slides()->idx_get(0);

// Agrega una autoforma rectángulo
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// Rota la forma 90 grados
autoShape->set_Rotation(90.f);

// Escribe el archivo PPTX en disco
pres->Save(u"RectShpRot_out.pptx", Export::SaveFormat::Pptx);
```

## **Agregar Efectos de Bisel 3D**
Aspose.Slides te permite agregar efectos de bisel 3D a una forma modificando sus propiedades de [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) a la diapositiva.
3. Establece tus parámetros preferidos para las propiedades de [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) de la forma.
4. Escribe la presentación en disco.

Este código C++ te muestra cómo agregar efectos de bisel 3D a una forma:

```cpp
// Instancia una clase de presentación que representa un archivo de presentación
auto pres = MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto slide = pres->get_Slides()->idx_get(0);

// Agrega una forma a la diapositiva
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
auto format = shape->get_LineFormat()->get_FillFormat();
format->set_FillType(FillType::Solid);
format->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Establece las propiedades de ThreeDFormat de la forma
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Escribe la presentación como un archivo PPTX
pres->Save(u"Bavel_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Agregar Efecto de Rotación 3D**
Aspose.Slides te permite aplicar efectos de rotación 3D a una forma modificando sus propiedades de [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) a la diapositiva.
3. Especifica tus figuras preferidas para [CameraType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_camera#aea0717e8ef5f3199df99ed2cb2ea2dcb) y [LightType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_light_rig#a2cd12029664967d0e2f93eee25a4963f).
4. Escribe la presentación en disco.

Este código C++ te muestra cómo aplicar efectos de rotación 3D a una forma:

```cpp
// Instancia una clase de presentación que representa un archivo de presentación
auto pres = MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto slide = pres->get_Slides()->idx_get(0);
    
// Agrega una forma a la diapositiva
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);

// Establece las propiedades de ThreeDFormat de la forma
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Agrega una forma a la diapositiva
shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 300, 200, 200);

// Establece las propiedades de ThreeDFormat de la forma
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(0, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Escribe la presentación como un archivo PPTX
pres->Save(u"Rotation_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Restablecer Formato**

Este código C++ te muestra cómo restablecer el formato en una diapositiva y revertir la posición, tamaño y formato de cada forma que tiene un marcador de posición en [LayoutSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.layout_slide) a sus valores predeterminados:

```c++
auto pres = System::MakeObject<Presentation>();

for (auto slide : pres->get_Slides())
{
    // cada forma en la diapositiva que tiene un marcador de posición en el diseño será revertida
    slide->Reset();
}
```