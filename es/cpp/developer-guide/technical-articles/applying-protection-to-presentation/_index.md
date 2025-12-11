---
title: Prevenir Ediciones de Presentación con Bloqueos de Forma
linktitle: Prevenir Ediciones de Presentación
type: docs
weight: 10
url: /es/cpp/applying-protection-to-presentation/
keywords:
- evitar ediciones
- proteger contra edición
- bloquear forma
- bloquear posición
- bloquear selección
- bloquear tamaño
- bloquear agrupación
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Descubra cómo Aspose.Slides for C++ bloquea o desbloquea formas en archivos PPT, PPTX y ODP, asegurando presentaciones mientras permite ediciones controladas y una entrega más rápida."
---

## **Antecedentes**

Un uso frecuente de Aspose.Slides es crear, actualizar y guardar presentaciones de Microsoft PowerPoint (PPTX) como parte de un flujo de trabajo automatizado. Los usuarios de aplicaciones que emplean Aspose.Slides de esta manera tienen acceso a las presentaciones generadas, por lo que protegerlas contra la edición es una preocupación común. Es importante que las presentaciones generadas automáticamente mantengan su formato y contenido original.

Este artículo explica cómo están estructuradas las presentaciones y diapositivas y cómo Aspose.Slides for C++ puede aplicar protección a una presentación y luego eliminarla. Proporciona a los desarrolladores una forma de controlar cómo se utilizan las presentaciones que generan sus aplicaciones.

## **Composición de una diapositiva**

Una diapositiva de presentación está compuesta por componentes como formas automáticas, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de video, conectores y otros elementos utilizados para crear una presentación. En Aspose.Slides for C++, cada elemento en una diapositiva está representado por un objeto que implementa la interfaz [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) o hereda de una clase que lo hace.

La estructura de PPTX es compleja, por lo que, a diferencia de PPT, donde se puede usar un bloqueo genérico para todos los tipos de formas, diferentes tipos de formas requieren bloqueos diferentes. La interfaz [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) es la clase de bloqueo genérica para PPTX. Los siguientes tipos de bloqueos son compatibles en Aspose.Slides for C++ para PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) bloquea formas automáticas.  
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) bloquea formas de conectores.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) bloquea objetos gráficos.  
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) bloquea formas agrupadas.  
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) bloquea marcos de imagen.   

Cualquier acción realizada en todos los objetos de forma en un objeto [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) se aplica a toda la presentación.

## **Aplicar y eliminar protección**

Aplicar protección garantiza que una presentación no pueda ser editada. Es una técnica útil para proteger el contenido de la presentación.

### **Aplicar protección a formas PPTX**

Aspose.Slides for C++ proporciona la interfaz [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) para trabajar con formas en una diapositiva.

Como se mencionó anteriormente, cada clase de forma tiene una clase de bloqueo de forma asociada para la protección. Este artículo se centra en los bloqueos NoSelect, NoMove y NoResize. Estos bloqueos aseguran que las formas no puedan ser seleccionadas (mediante clics del ratón u otros métodos de selección) y que no puedan ser movidas ni redimensionadas.

El ejemplo de código que sigue aplica protección a todos los tipos de forma en una presentación.
```cpp
// Instanciar la clase Presentation que representa un archivo PPTX.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Recorrer todas las diapositivas de la presentación.
for (auto&& slide : presentation->get_Slides())	{

	// Recorrer todas las formas de la diapositiva.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Convertir la forma a una autoshape y obtener su bloqueo de forma.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Convertir la forma a una forma agrupada y obtener su bloqueo de forma.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Convertir la forma a una forma conector y obtener su bloqueo de forma.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Convertir la forma a un marco de imagen y obtener su bloqueo de forma.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Guardar el archivo de la presentación.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


### **Eliminar protección**

Para desbloquear una forma, establezca el valor del bloqueo aplicado a `false`. El siguiente ejemplo de código muestra cómo desbloquear formas en una presentación bloqueada.
```cpp
// Instanciar la clase Presentation que representa un archivo PPTX.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Recorrer todas las diapositivas de la presentación.
for (auto&& slide : presentation->get_Slides())	{

	// Recorrer todas las formas de la diapositiva.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Convertir la forma a una autoshape y obtener su bloqueo de forma.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Convertir la forma a una forma agrupada y obtener su bloqueo de forma.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Convertir la forma a una forma conector y obtener su bloqueo de forma.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Convertir la forma a un marco de imagen y obtener su bloqueo de forma.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Guardar el archivo de la presentación.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Conclusión**

Aspose.Slides ofrece varias opciones para proteger formas en una presentación. Puede bloquear una forma individual o iterar a través de todas las formas de una presentación y bloquear cada una para asegurar eficazmente todo el archivo. Puede eliminar la protección estableciendo el valor del bloqueo a `false`.

## **FAQ**

**¿Puedo combinar bloqueos de forma y protección con contraseña en la misma presentación?**

Sí. Los bloqueos limitan la edición de objetos dentro del archivo, mientras que la [password protection](/slides/es/cpp/password-protected-presentation/) controla el acceso a la apertura y/o el guardado de cambios. Estos mecanismos se complementan y funcionan juntos.

**¿Puedo restringir la edición en diapositivas específicas sin afectar a otras?**

Sí. Aplique bloqueos a las formas en las diapositivas seleccionadas; las diapositivas restantes permanecerán editables.

**¿Los bloqueos de forma se aplican a objetos agrupados y conectores?**

Sí. Se admiten tipos de bloqueo dedicados para grupos, conectores, objetos gráficos y otros tipos de forma.