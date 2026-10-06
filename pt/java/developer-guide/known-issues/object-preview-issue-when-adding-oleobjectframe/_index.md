---
title: Marcador de Visualização de Objeto ao Adicionar OleObjectFrame
linktitle: Marcador de Visualização OLE
type: docs
weight: 10
url: /pt/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de visualização
- marcador de visualização
- por design
- objeto incorporado
- arquivo incorporado
- objeto alterado
- visualização do objeto
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Por que um objeto OLE adicionado com Aspose.Slides for Java exibe um marcador EMBEDDED OLE OBJECT até que sua visualização seja atualizada, e como definir sua própria imagem de visualização."
---
## **Introdução**

Usando o Aspose.Slides for Java, ao adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/oleobjectframe/) a um slide, uma mensagem "EMBEDDED OLE OBJECT" é exibida no slide de saída. Esta mensagem é intencional e NÃO é um bug.

Para obter mais informações sobre como trabalhar com objetos OLE, veja [Gerenciar OLE](/slides/pt/java/manage-ole/).

## **Explicação e Solução**

O Aspose.Slides exibe a mensagem "EMBEDDED OLE OBJECT" para informar que o objeto OLE foi alterado e que a imagem de visualização precisa ser atualizada.

Por exemplo, se você adicionar um gráfico do Microsoft Excel como um [OleObjectFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/oleobjectframe/) a um slide (para mais detalhes, veja o artigo "Manage OLE") e então abrir a apresentação no Microsoft PowerPoint, verá esta imagem no slide:

![OLE object message](OLE_object_message.png)

Se você quiser verificar e confirmar que seu objeto OLE foi adicionado ao slide, deve dar duplo clique na mensagem "EMBEDDED OLE OBJECT", ou pode clicar com o botão direito nela e seguir a opção **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

O PowerPoint então abre o objeto OLE incorporado.

![OLE object data](OLE_object_data.png)

O slide pode manter a mensagem "EMBEDDED OLE OBJECT". Quando você clicar no objeto OLE, a visualização do slide é atualizada e a mensagem "EMBEDDED OLE OBJECT" é substituída pela imagem real do objeto OLE.

![OLE object preview](OLE_object_preview.png)

Agora, você pode querer salvar sua apresentação para garantir que a imagem do Objeto OLE seja atualizada corretamente. Dessa forma, após salvar a apresentação, ao abri-la novamente, você NÃO verá a mensagem "EMBEDDED OLE OBJECT".

## **Outra Solução**

Se você não quiser remover a mensagem "EMBEDDED OLE OBJECT" abrindo a apresentação no PowerPoint e salvando-a, pode substituir a mensagem pela sua imagem de visualização preferida. Estas linhas de código demonstram o processo. Elas presumem que a primeira forma no primeiro slide de *embeddedOLE.pptx* é a moldura do objeto OLE e que *myImage.png* contém a imagem a ser exibida, e salvam o resultado como *embeddedOLE‑newImage.pptx*:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Adicionar uma imagem aos recursos da apresentação.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // Definir a imagem para a visualização do objeto OLE.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O slide que contém o `OleObjectFrame` então muda para isto:

![New OLE object image](OLE_object_new_image.png)