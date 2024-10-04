---
title: Bloqueo de Presentación
type: docs
weight: 110
url: /net/presentation-locking/
---

## **Bloqueo de Presentación**
Un uso común de **Aspose.Slides** es crear, actualizar y guardar presentaciones de Microsoft PowerPoint 2007 (PPTX) como parte de un flujo de trabajo automatizado. Los usuarios de la aplicación que utiliza Aspose.Slides de esta manera tienen acceso a las presentaciones resultantes. Protegerlas contra la edición es una preocupación común. Es importante que las presentaciones generadas automáticamente mantengan su formato y contenido originales.

Esto explica cómo se construyen las presentaciones y las diapositivas y cómo Aspose.Slides para .NET puede aplicar protección a, y luego quitarla de, una presentación. Esta función es única de Aspose.Slides y, en el momento de escribir, no está disponible en Microsoft PowerPoint. Proporciona a los desarrolladores una forma de controlar cómo se utilizan las presentaciones que sus aplicaciones crean.
## **Composición de una Diapositiva**
Una diapositiva PPTX está compuesta por varios componentes como formas automáticas, tablas, objetos OLE, formas agrupadas, marcos de imágenes, marcos de video, conectores y otros elementos disponibles para construir una presentación.

En Aspose.Slides para .NET, cada elemento en una diapositiva se convierte en un objeto Shape. En otras palabras, cada elemento en la diapositiva es un objeto Shape o un objeto derivado del objeto Shape.

La estructura de PPTX es compleja, por lo que a diferencia de PPT, donde se puede usar un bloqueo genérico para todos los tipos de formas, hay diferentes tipos de bloqueos para diferentes tipos de formas. La clase BaseShapeLock es la clase de bloqueo genérico de PPTX. Los siguientes tipos de bloqueos son compatibles en Aspose.Slides para .NET para PPTX.

- AutoShapeLock bloquea formas automáticas.
- ConnectorLock bloquea formas de conector.
- GraphicalObjectLock bloquea objetos gráficos.
- GroupshapeLock bloquea formas grupales.
- PictureFrameLock bloquea marcos de imágenes.

Cualquier acción realizada en todos los objetos Shape en un objeto Presentation se aplica a toda la presentación.
## **Aplicando y Eliminando Protección**
Aplicar protección asegura que una presentación no pueda ser editada. Es una técnica útil para proteger el contenido de una presentación.

**Aplicando Protección a Formas PPTX**

Aspose.Slides para .NET proporciona la clase Shape para manejar una forma en la diapositiva.

Como se mencionó anteriormente, cada clase de forma tiene una clase de bloqueo asociada para protección. Este artículo se centra en los bloqueos NoSelect, NoMove y NoResize. Estos bloqueos aseguran que las formas no puedan ser seleccionadas (a través de clics del mouse u otros métodos de selección), y no puedan ser movidas o redimensionadas.

Los ejemplos de código que siguen aplican protección a todos los tipos de formas en una presentación.

``` csharp

 //Instanciar la clase Presentation que representa un archivo PPTX

PresentationEx pTemplate = new PresentationEx("Aplicando Protección.pptx");//Instanciar la clase Presentation que representa un archivo PPTX


//ISlide objeto para acceder a las diapositivas en la presentación

SlideEx slide = pTemplate.Slides[0];

//IShape objeto para contener formas temporales

ShapeEx shape;

//Recorriendo todas las diapositivas en la presentación

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Recorriendo todas las formas en las diapositivas

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//si la forma es una forma automática

		if (shape is AutoShapeEx)

		{

			//Casting a forma automática y obteniendo el bloqueo de forma automática

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Aplicando bloqueos de formas

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//si la forma es una forma grupal

		else if (shape is GroupShapeEx)

		{

			//Casting a forma grupal y obteniendo el bloqueo de forma grupal

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Aplicando bloqueos de formas

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//si la forma es un conector

		else if (shape is ConnectorEx)

		{

			//Casting a forma de conector y obteniendo el bloqueo de forma de conector

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Aplicando bloqueos de formas

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//si la forma es un marco de imagen

		else if (shape is PictureFrameEx)

		{

			//Casting a forma de marco de imagen y obteniendo el bloqueo de forma de marco de imagen

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Aplicando bloqueos de formas

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Guardar el archivo de presentación

pTemplate.Save("SampleProtegido.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Eliminando Protección**

La protección aplicada mediante Aspose.Slides para .NET solo puede ser eliminada con Aspose.Slides para .NET. Para desbloquear una forma, establezca el valor del bloqueo aplicado en false. El ejemplo de código que sigue muestra cómo desbloquear formas en una presentación bloqueada.

``` csharp

 //Abrir la presentación deseada

PresentationEx pTemplate = new PresentationEx("SampleProtegido.pptx");
//ISlide objeto para acceder a las diapositivas en la presentación

SlideEx slide = pTemplate.Slides[0];

//IShape objeto para contener formas temporales

ShapeEx shape;

//Recorriendo todas las diapositivas en la presentación

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Recorriendo todas las formas en las diapositivas

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//si la forma es una forma automática

		if (shape is AutoShapeEx)

		{

			//Casting a forma automática y obteniendo el bloqueo de forma automática

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Aplicando bloqueos de formas

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//si la forma es una forma grupal

		else if (shape is GroupShapeEx)

		{

			//Casting a forma grupal y obteniendo el bloqueo de forma grupal

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Aplicando bloqueos de formas

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//si la forma es una forma de conector

		else if (shape is ConnectorEx)

		{

			//Casting a forma de conector y obteniendo el bloqueo de forma de conector

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Aplicando bloqueos de formas

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//si la forma es un marco de imagen

		else if (shape is PictureFrameEx)

		{

			//Casting a forma de marco de imagen y obteniendo el bloqueo de forma de marco de imagen

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Aplicando bloqueos de formas

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Guardar el archivo de presentación

pTemplate.Save("SampleEliminarProtección.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812535)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)