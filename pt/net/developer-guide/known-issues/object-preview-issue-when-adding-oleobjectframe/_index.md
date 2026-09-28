---
title: Marcador de posição da visualização do objeto ao adicionar OleObjectFrame
linktitle: Marcador de visualização OLE
type: docs
weight: 10
url: /pt/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de visualização
- marcador de visualização
- por design
- objeto incorporado
- arquivo incorporado
- objeto alterado
- visualização do objeto
- apresentação
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Por que um objeto OLE adicionado com Aspose.Slides para .NET mostra um marcador EMBEDDED OLE OBJECT até que sua visualização seja atualizada, e como definir sua própria imagem de visualização."
---
## **Introdução**

Usando Aspose.Slides para .NET, ao adicionar [OleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/oleobjectframe/) a um slide, uma mensagem "EMBEDDED OLE OBJECT" é exibida no slide de saída. Esta mensagem é intencional e NÃO é um bug.

Para mais informações sobre como trabalhar com objetos OLE, veja [Manage OLE](/slides/pt/net/manage-ole/).

## **Explicação e Solução**

Aspose.Slides exibe a mensagem "EMBEDDED OLE OBJECT" para notificar que o objeto OLE foi alterado e a imagem de visualização precisa ser atualizada.

Por exemplo, se você adicionar um gráfico do Microsoft Excel como um [OleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/oleobjectframe/) a um slide (para mais detalhes, veja o artigo "Manage OLE") e então abrir a apresentação no Microsoft PowerPoint, verá esta imagem no slide:

![Mensagem do objeto OLE](OLE_object_message.png)

Se você quiser verificar e confirmar que seu objeto OLE foi adicionado ao slide, deve dar um duplo clique na mensagem "EMBEDDED OLE OBJECT", ou pode clicar com o botão direito nela e percorrer a opção **Object > Edit**.

![Objeto OLE > Editar](OLE_object_edit.png)

O PowerPoint então abre o objeto OLE incorporado.

![Dados do objeto OLE](OLE_object_data.png)

O slide pode manter a mensagem "EMBEDDED OLE OBJECT". Quando você clica no objeto OLE, a visualização do slide é atualizada e a mensagem "EMBEDDED OLE OBJECT" é substituída pela imagem real do objeto OLE.

![Pré-visualização do objeto OLE](OLE_object_preview.png)

Agora, você pode querer salvar sua apresentação para garantir que a imagem do Objeto OLE seja atualizada corretamente. Dessa forma, após salvar a apresentação, ao abri‑la novamente, você NÃO verá a mensagem "EMBEDDED OLE OBJECT".

## **Outras Soluções**

### **Solução 1: Substituir a mensagem "Embedded OLE Object" por uma imagem**

Se você não quiser remover a mensagem "EMBEDDED OLE OBJECT" abrindo a apresentação no PowerPoint e, em seguida, salvando‑a, pode substituir a mensagem pela sua imagem de visualização preferida. Estas linhas de código demonstram o processo:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Adicionar uma imagem aos recursos da apresentação.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Definir a imagem para a visualização do objeto OLE.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

O slide contendo o `OleObjectFrame` então muda para isto:

![Nova imagem do objeto OLE](OLE_object_new_image.png)

### **Solução 2: Criar um Add‑On para PowerPoint**

Você também pode criar um add‑on para o Microsoft PowerPoint que atualiza todos os objetos OLE quando você abre apresentações no programa.