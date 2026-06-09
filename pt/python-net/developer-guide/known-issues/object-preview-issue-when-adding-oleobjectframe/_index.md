---
title: Problema de Visualização de Objeto ao Adicionar OleObjectFrame
linktitle: Problema de Objeto OLE
type: docs
weight: 10
url: /pt/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de visualização
- incorporar objeto
- incorporar arquivo
- objeto alterado
- visualização do objeto
- apresentação
- PowerPoint
- Python
- Aspose.Slides
description: "Saiba por que a mensagem EMBEDDED OLE OBJECT aparece ao adicionar OleObjectFrame no Aspose.Slides para Python e como corrigir problemas de visualização em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Usando Aspose.Slides para Python via .NET, ao adicionar [OleObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/) a um slide, uma mensagem "EMBEDDED OLE OBJECT" é exibida no slide de saída. Essa mensagem é intencional e NÃO é um bug.

Para mais informações sobre como trabalhar com objetos OLE, veja [Manage OLE](/slides/pt/python-net/manage-ole/). 

## **Explicação e Solução**

Aspose.Slides exibe a mensagem "EMBEDDED OLE OBJECT" para notificar que o objeto OLE foi alterado e a imagem de visualização precisa ser atualizada. 

Por exemplo, se você adicionar um gráfico do Microsoft Excel como um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/) a um slide (para mais detalhes, veja o artigo "Manage OLE") e então abrir a apresentação no Microsoft PowerPoint, verá esta imagem no slide:

![OLE object message](OLE_object_message.png)

Se você quiser verificar e confirmar que seu objeto OLE foi adicionado ao slide, deve clicar duas vezes na mensagem "EMBEDDED OLE OBJECT", ou pode clicar com o botão direito nela e seguir a opção **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

O PowerPoint então abre o objeto OLE incorporado.

![OLE object data](OLE_object_data.png)

O slide pode manter a mensagem "EMBEDDED OLE OBJECT". Quando você clica no objeto OLE, a visualização do slide é atualizada e a mensagem "EMBEDDED OLE OBJECT" é substituída pela imagem real do objeto OLE. 

![OLE object preview](OLE_object_preview.png)

Agora, talvez você queira salvar sua apresentação para garantir que a imagem do Objeto OLE seja atualizada corretamente. Dessa forma, após salvar a apresentação, ao abri‑la novamente, você NÃO verá a mensagem "EMBEDDED OLE OBJECT". 

## **Outras Soluções**

### **Solução 1: Substituir a mensagem "Embedded OLE Object" por uma imagem**

Se você não quiser remover a mensagem "EMBEDDED OLE OBJECT" abrindo a apresentação no PowerPoint e depois salvando‑a, pode substituir a mensagem pela sua imagem de visualização preferida. Estas linhas de código demonstram o processo:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Adicione uma imagem aos recursos da apresentação.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Defina um título e a imagem para a visualização do objeto OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

O slide que contém o `OleObjectFrame` então muda para isto:

![New OLE object image](OLE_object_new_image.png)

### **Solução 2: Criar um add‑on para o PowerPoint**

Você também pode criar um add‑on para o Microsoft PowerPoint que atualiza todos os objetos OLE ao abrir apresentações no programa.