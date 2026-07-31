---
title: Problema de Visualização de Objeto ao Adicionar OleObjectFrame
linktitle: Problema de Objeto OLE
type: docs
weight: 10
url: /pt/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de visualização
- objeto incorporado
- arquivo incorporado
- objeto alterado
- visualização do objeto
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Saiba por que o EMBEDDED OLE OBJECT aparece ao adicionar OleObjectFrame no Aspose.Slides para Node.js e como corrigir problemas de visualização em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Usando Aspose.Slides for Java, ao adicionar [OleObjectFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/oleobjectframe/) a um slide, a mensagem “EMBEDDED OLE OBJECT” é exibida no slide de saída. Essa mensagem é intencional e NÃO é um bug.

Para obter mais informações sobre como trabalhar com objetos OLE, veja [Gerenciar OLE](/slides/pt/nodejs-java/manage-ole/). 

## **Explicação e Solução**

Aspose.Slides exibe a mensagem “EMBEDDED OLE OBJECT” para notificar que o objeto OLE foi alterado e a imagem de visualização precisa ser atualizada. 

Por exemplo, se você adicionar um gráfico do Microsoft Excel como um [OleObjectFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/oleobjectframe/) a um slide (para mais detalhes, consulte o artigo “Gerenciar OLE”) e depois abrir a apresentação no Microsoft PowerPoint, verá esta imagem no slide:

![Mensagem de objeto OLE](OLE_object_message.png)

Se quiser verificar e confirmar que seu objeto OLE foi adicionado ao slide, é necessário dar um duplo clique na mensagem “EMBEDDED OLE OBJECT”, ou clicar com o botão direito nela e acessar a opção **Objeto > Editar**.

![OLE object > Edit](OLE_object_edit.png)

O PowerPoint então abre o objeto OLE incorporado.

![Dados do objeto OLE](OLE_object_data.png)

O slide pode reter a mensagem “EMBEDDED OLE OBJECT”. Quando você clicar no objeto OLE, a visualização do slide é atualizada e a mensagem “EMBEDDED OLE OBJECT” é substituída pela imagem real do objeto OLE. 

![Pré‑visualização do objeto OLE](OLE_object_preview.png)

Agora, você pode salvar sua apresentação para garantir que a imagem do Objeto OLE seja atualizada corretamente. Dessa forma, após salvar a apresentação, ao abri‑la novamente, você NÃO verá a mensagem “EMBEDDED OLE OBJECT”. 

## **Outras Soluções**

### **Solução 1: Substituir a mensagem “EMBEDDED OLE OBJECT” por uma Imagem**

Se não quiser remover a mensagem “EMBEDDED OLE OBJECT” abrindo a apresentação no PowerPoint e depois salvando‑a, pode substituir a mensagem pela imagem de visualização de sua preferência. Estas linhas de código demonstram o processo:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Adiciona uma imagem aos recursos da apresentação.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Define um título e a imagem para a visualização do objeto OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

O slide que contém o `OleObjectFrame` então passa a ser este:

![Nova imagem do objeto OLE](OLE_object_new_image.png)

### **Solução 2: Criar um Complemento para PowerPoint**

Você também pode criar um complemento para o Microsoft PowerPoint que atualiza todos os objetos OLE ao abrir apresentações no programa.