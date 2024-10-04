---
title: Problema de Objeto Cambiado al Agregar OleObjectFrame
type: docs
weight: 10
url: /net/object-changed-issue-when-adding-oleobjectframe/
---

{{% alert color="primary" %}} 

Al usar Aspose.Slides para .NET, cuando agregas **[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)** a una diapositiva, se muestra un mensaje de **Objeto Cambiado** en la diapositiva de salida (y NO en el objeto OLE). El proceso descrito es una acción deliberada y NO un error. 

Para obtener más información sobre cómo trabajar con objetos OLE, consulta [Gestionar OLE](/slides/net/manage-ole/). 

{{% /alert %}} 
## **Explicación** y Solución
Aspose.Slides muestra el mensaje **Objeto Cambiado** para notificarte que el objeto OLE ha sido cambiado y la imagen de vista previa debe actualizarse. 

Por ejemplo, si agregas un gráfico de Microsoft Excel como un **[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)** a una diapositiva (para más detalles, consulta el artículo Gestionar OLE) y luego abres la presentación en la aplicación Microsoft PowerPoint, verás esta imagen en la diapositiva:

~~Reemplazar todas las imágenes por nuevas imágenes~~

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

Si deseas verificar y confirmar que tu objeto OLE fue agregado a la diapositiva, tienes que hacer doble clic en el mensaje **Objeto Cambiado**, o puedes hacer clic derecho en él y elegir la opción **Objeto de Hoja de Cálculo > Editar.**

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

PowerPoint abrirá entonces el objeto OLE incrustado.

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)



La diapositiva puede conservar el mensaje **Objeto Cambiado**. Una vez que hagas clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje **Objeto Cambiado** es reemplazado por la imagen real del objeto OLE. 

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

Ahora, es posible que desees guardar tu presentación para asegurar que la imagen del Objeto OLE se actualice correctamente. De esta manera, después de guardar la presentación, cuando abras la presentación nuevamente, NO verás el mensaje **Objeto Cambiado**. 

## **Otras Soluciones**
### **Solución 1: Reemplazar el Mensaje de Objeto Cambiado con una Imagen**

Si no deseas eliminar el mensaje **Objeto Cambiado** abriendo la presentación en PowerPoint y luego guardándola, puedes reemplazar el mensaje con tu imagen de vista previa preferida. Estas líneas de código demuestran el proceso:

``` csharp 
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
   ISlide slide = pres.Slides[0];
   IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    
   IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("my_image.png"));
   oleObjectFrame.SubstitutePictureTitle = "Mi título";
   oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
   oleObjectFrame.IsObjectIcon = false;
    
   pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```

La diapositiva que contiene el `OleObjectFrame` cambia entonces a esto:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

### **Solución 2: Crear un Complemento para PowerPoint**
También puedes crear un complemento para Microsoft PowerPoint que actualice todos los objetos OLE cuando abras presentaciones en el programa.