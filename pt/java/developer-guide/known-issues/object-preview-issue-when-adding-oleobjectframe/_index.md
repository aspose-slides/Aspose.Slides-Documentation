---
title: Problema de Visualização de Objeto ao Adicionar OleObjectFrame
linktitle: Problema de Objeto OLE
type: docs
weight: 10
url: /pt/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de visualização
- objeto incorporado
- arquivo incorporado
- objeto alterado
- visualização do objeto
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda por que o EMBEDDED OLE OBJECT aparece ao adicionar OleObjectFrame no Aspose.Slides para Java e como corrigir problemas de visualização em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Usando Aspose.Slides para Java, ao adicionar [OleObjectFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/oleobjectframe/) a um slide, uma mensagem "EMBEDDED OLE OBJECT" é exibida no slide de saída. Essa mensagem é intencional e NÃO é um bug.

Para mais informações sobre como trabalhar com objetos OLE, veja [Manage OLE](/slides/pt/java/manage-ole/). 

## **Explicação e Solução**

Aspose.Slides exibe a mensagem "EMBEDDED OLE OBJECT" para notificar que o objeto OLE foi alterado e a imagem de visualização precisa ser atualizada. 

Por exemplo, se você adicionar um gráfico do Microsoft Excel como um [OleObjectFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/oleobjectframe/) a um slide (para mais detalhes, veja o artigo "Manage OLE") e então abrir a apresentação no Microsoft PowerPoint, verá esta imagem no slide:

![OLE object message](OLE_object_message.png)

Se quiser verificar e confirmar que seu objeto OLE foi adicionado ao slide, você deve clicar duas vezes na mensagem "EMBEDDED OLE OBJECT", ou pode clicar com o botão direito nela e passar pela opção **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

O PowerPoint então abre o objeto OLE incorporado.

![OLE object data](OLE_object_data.png)

O slide pode manter a mensagem "EMBEDDED OLE OBJECT". Quando você clica no objeto OLE, a visualização do slide é atualizada e a mensagem "EMBEDDED OLE OBJECT" é substituída pela imagem real do objeto OLE. 

![OLE object preview](OLE_object_preview.png)

Agora, você pode querer salvar sua apresentação para garantir que a imagem do objeto OLE seja atualizada corretamente. Dessa forma, após salvar a apresentação, ao abri‑la novamente, você NÃO verá a mensagem "EMBEDDED OLE OBJECT". 

## **Outra Solução**

Se você não quiser remover a mensagem "EMBEDDED OLE OBJECT" abrindo a apresentação no PowerPoint e salvando‑a, pode substituir a mensagem pela sua imagem de visualização preferida. Estas linhas de código demonstram o processo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Adicionar uma imagem aos recursos da apresentação.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Definir um título e a imagem para a visualização do objeto OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

O slide contendo o `OleObjectFrame` então muda para isto:

![New OLE object image](OLE_object_new_image.png)