---
title: Problema de Visualização de Objeto ao Adicionar OleObjectFrame
linktitle: Problema de Objeto OLE
type: docs
weight: 10
url: /pt/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de visualização
- objeto incorporado
- arquivo incorporado
- objeto alterado
- visualização do objeto
- apresentação
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Saiba por que o EMBEDDED OLE OBJECT aparece ao adicionar OleObjectFrame no Aspose.Slides para .NET e como corrigir problemas de visualização em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Usando Aspose.Slides for .NET, ao adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/oleobjectframe) a um slide, uma mensagem "EMBEDDED OLE OBJECT" é exibida no slide de saída. Essa mensagem é intencional e NÃO é um bug.

Para obter mais informações sobre como trabalhar com objetos OLE, consulte [Gerenciar OLE](/slides/pt/net/manage-ole/). 

## **Explicação e Solução**

Aspose.Slides exibe a mensagem "EMBEDDED OLE OBJECT" para notificar que o objeto OLE foi alterado e a imagem de visualização precisa ser atualizada. 

Por exemplo, se você adicionar um gráfico do Microsoft Excel como um [OleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/oleobjectframe) a um slide (para mais detalhes, veja o artigo "Gerenciar OLE") e, em seguida, abrir a apresentação no Microsoft PowerPoint, verá esta imagem no slide:

![mensagem do objeto OLE](OLE_object_message.png)

Se quiser verificar e confirmar que seu objeto OLE foi adicionado ao slide, você deve clicar duas vezes na mensagem "EMBEDDED OLE OBJECT", ou pode clicar com o botão direito sobre ela e usar a opção **Objeto > Editar**.

![Objeto OLE > Editar](OLE_object_edit.png)

O PowerPoint então abre o objeto OLE incorporado.

![dados do objeto OLE](OLE_object_data.png)

O slide pode manter a mensagem "EMBEDDED OLE OBJECT". Quando você clicar no objeto OLE, a visualização do slide é atualizada e a mensagem "EMBEDDED OLE OBJECT" é substituída pela imagem real do objeto OLE. 

![pré‑visualização do objeto OLE](OLE_object_preview.png)

Agora, você pode salvar sua apresentação para garantir que a imagem do Objeto OLE seja atualizada corretamente. Dessa forma, após salvar a apresentação, ao abri‑la novamente, você NÃO verá a mensagem "EMBEDDED OLE OBJECT". 

## **Outras Soluções**

### **Solução 1: Substituir a mensagem "Embedded OLE Object" por uma imagem**

Se não quiser remover a mensagem "EMBEDDED OLE OBJECT" abrindo a apresentação no PowerPoint e, em seguida, salvando-a, pode substituir a mensagem pela sua imagem de pré‑visualização preferida. Estas linhas de código demonstram o processo:

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

O slide contendo o `OleObjectFrame` então passa a ser este:

![Nova imagem do objeto OLE](OLE_object_new_image.png)

### **Solução 2: Criar um complemento para PowerPoint**

Você também pode criar um complemento para o Microsoft PowerPoint que atualiza todos os objetos OLE ao abrir apresentações no programa.