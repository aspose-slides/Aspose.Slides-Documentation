---
title: Bloqueo de presentaciones
type: docs
weight: 110
url: /es/net/presentation-locking/
---

## **Bloqueo de Presentaciones**
Un uso frecuente de **Aspose.Slides** es crear, actualizar y guardar presentaciones de Microsoft PowerPoint 2007 (PPTX) como parte de un flujo de trabajo automatizado. Los usuarios de la aplicación que emplea Aspose.Slides de esta forma acceden a las presentaciones generadas. Protegerlas contra la edición es una preocupación habitual. Es importante que las presentaciones generadas automáticamente conserven su formato y contenido originales.

Esto explica cómo se construyen las presentaciones y diapositivas y cómo Aspose.Slides para .NET puede aplicar protección a una presentación y, posteriormente, eliminarla. Esta característica es exclusiva de Aspose.Slides y, al momento de escribir, no está disponible en Microsoft PowerPoint. Ofrece a los desarrolladores una forma de controlar el uso de las presentaciones creadas por sus aplicaciones.
## **Composición de una Diapositiva**
Una diapositiva PPTX se compone de varios componentes como formas automáticas, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de vídeo, conectores y los diversos elementos disponibles para construir una presentación.

En Aspose.Slides para .NET, cada elemento de una diapositiva se convierte en un objeto Shape. En otras palabras, cada elemento de la diapositiva es un objeto Shape o un objeto derivado de Shape.

La estructura de PPTX es compleja, por lo que, a diferencia de PPT, donde se puede usar un bloqueo genérico para todo tipo de formas, existen diferentes tipos de bloqueos para cada tipo de forma. La clase BaseShapeLock es la clase genérica de bloqueo PPTX. Los siguientes tipos de bloqueos son compatibles en Aspose.Slides para .NET para PPTX.

- AutoShapeLock bloquea formas automáticas.
- ConnectorLock bloquea formas conectoras.
- GraphicalObjectLock bloquea objetos gráficos.
- GroupshapeLock bloquea grupos de formas.
- PictureFrameLock bloquea marcos de imagen.

Cualquier acción realizada sobre todos los objetos Shape en un objeto Presentation se aplica a toda la presentación.
## **Aplicar y Eliminar Protección**
Aplicar protección garantiza que una presentación no pueda ser editada. Es una técnica útil para proteger el contenido de una presentación.

**Aplicar Protección a Formas PPTX**

Aspose.Slides para .NET proporciona la clase Shape para gestionar una forma en la diapositiva.

Como se mencionó antes, cada clase de forma tiene una clase de bloqueo de forma asociada para la protección. Este artículo se centra en los bloqueos NoSelect, NoMove y NoResize. Estos bloqueos aseguran que las formas no puedan ser seleccionadas (mediante clics del ratón u otros métodos de selección) y que no puedan moverse ni redimensionarse.

Los ejemplos de código que siguen aplican protección a todos los tipos de forma en una presentación.

``` csharp

 //Instatiate Presentation class that represents a PPTX file

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instatiate Presentation class that represents a PPTX file


//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in the presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//if shape is a connector

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to picture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Saving the presentation file

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Eliminar Protección**

La protección aplicada con Aspose.Slides para .NET solo puede eliminarse con Aspose.Slides para .NET. Para desbloquear una forma, establezca el valor del bloqueo aplicado a false. El ejemplo de código que sigue muestra cómo desbloquear formas en una presentación protegida.

``` csharp

 //Open the desired presentation

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//if shape is Connector shape

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to pitcture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Saving the presentation file

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Descargar Código de Ejemplo**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)