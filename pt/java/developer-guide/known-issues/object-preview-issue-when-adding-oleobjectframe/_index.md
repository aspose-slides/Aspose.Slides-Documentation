---
title: Problema de Visualização de Objeto ao Adicionar OleObjectFrame
linktitle: Problema de Objeto OLE
type: docs
weight: 10
url: /pt/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de visualização
- incorporar objeto
- incorporar arquivo
- objeto alterado
- visualização do objeto
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Saiba por que EMBEDDED OLE OBJECT aparece ao adicionar OleObjectFrame no Aspose.Slides para Java e como corrigir problemas de visualização em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Usando Aspose.Slides for Java, ao adicionar [OleObjectFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/oleobjectframe/) a um slide, uma mensagem "EMBEDDED OLE OBJECT" é exibida no slide de saída. Essa mensagem é intencional e NÃO é um bug.

Para obter mais informações sobre como trabalhar com objetos OLE, veja [Gerenciar OLE](/slides/pt/java/manage-ole/).

## **Explicação e Solução**

Aspose.Slides exibe a mensagem "EMBEDDED OLE OBJECT" para notificar que o objeto OLE foi alterado e a imagem de visualização precisa ser atualizada.

Por exemplo, se você adicionar um gráfico do Microsoft Excel como um [OleObjectFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/oleobjectframe/) a um slide (para mais detalhes, veja o artigo "Manage OLE") e então abrir a apresentação no Microsoft PowerPoint, verá esta imagem no slide:

![Mensagem do objeto OLE](OLE_object_message.png)

Se você quiser verificar e confirmar que seu objeto OLE foi adicionado ao slide, deve dar um duplo clique na mensagem "EMBEDDED OLE OBJECT", ou pode clicar com o botão direito nela e percorrer a opção **Object > Edit**.

![Objeto OLE > Editar](OLE_object_edit.png)

O PowerPoint então abre o objeto OLE incorporado.

![Dados do objeto OLE](OLE_object_data.png)

O slide pode manter a mensagem "EMBEDDED OLE OBJECT". Quando você clicar no objeto OLE, a visualização do slide é atualizada e a mensagem "EMBEDDED OLE OBJECT" é substituída pela imagem real do objeto OLE.

![Pré-visualização do objeto OLE](OLE_object_preview.png)

Agora, pode ser que você queira salvar sua apresentação para garantir que a imagem do Objeto OLE seja atualizada corretamente. Dessa forma, após salvar a apresentação, ao abri-la novamente, você NÃO verá a mensagem "EMBEDDED OLE OBJECT".

## **Outras Soluções**

### **Solução 1: Substituir a mensagem "Embedded OLE Object" por uma imagem**

Se você não quiser remover a mensagem "EMBEDDED OLE OBJECT" abrindo a apresentação no PowerPoint e então salvando-a, pode substituir a mensagem pela sua imagem de visualização preferida. Estas linhas de código demonstram o processo:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Adicionar uma imagem aos recursos da apresentação.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Defina um título e a imagem para a visualização do objeto OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

O slide que contém o `OleObjectFrame` então muda para isto:

![Nova imagem do objeto OLE](OLE_object_new_image.png)

### **Solução 2: Criar um Add‑On para PowerPoint**

Você também pode criar um add‑on para o Microsoft PowerPoint que atualiza todos os objetos OLE quando você abre apresentações no programa.