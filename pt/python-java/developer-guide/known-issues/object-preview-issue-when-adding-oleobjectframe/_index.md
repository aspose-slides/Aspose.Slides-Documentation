---
title: Problema de Visualização de Objeto ao Adicionar OleObjectFrame
linktitle: Problema de Objeto OLE
type: docs
weight: 10
url: /pt/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de visualização
- incorporar objeto
- incorporar arquivo
- objeto alterado
- visualização do objeto
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Saiba por que EMBEDDED OLE OBJECT aparece ao adicionar OleObjectFrame no Aspose.Slides para Python via Java e como corrigir problemas de visualização em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Ao usar Aspose.Slides para Python via Java para adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/) a um slide, a mensagem "EMBEDDED OLE OBJECT" é exibida no slide de saída. Essa mensagem é intencional e não é um bug.

Para mais informações sobre como trabalhar com objetos OLE, veja [Gerenciar OLE](/slides/pt/python-java/manage-ole/).

## **Explicação e Solução**

Aspose.Slides exibe a mensagem "EMBEDDED OLE OBJECT" para notificar que o objeto OLE foi alterado e a imagem de visualização precisa ser atualizada.

Por exemplo, se você adicionar um gráfico do Microsoft Excel como um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/) a um slide (para mais detalhes, consulte o artigo "Gerenciar OLE") e então abrir a apresentação no Microsoft PowerPoint, verá esta imagem no slide:

![Mensagem de objeto OLE](OLE_object_message.png)

Para confirmar que seu objeto OLE foi adicionado ao slide, clique duas vezes na mensagem "EMBEDDED OLE OBJECT" ou clique com o botão direito nela e selecione **Object > Edit**.

![Objeto OLE > Editar](OLE_object_edit.png)

O PowerPoint então abre o objeto OLE incorporado.

![Dados do objeto OLE](OLE_object_data.png)

O slide pode manter a mensagem "EMBEDDED OLE OBJECT". Quando você clicar no objeto OLE, a visualização do slide será atualizada e a mensagem "EMBEDDED OLE OBJECT" será substituída pela imagem real do objeto OLE.

![Visualização do objeto OLE](OLE_object_preview.png)

Salve sua apresentação para preservar a imagem de visualização atualizada do objeto OLE. Quando abrir a apresentação novamente, não verá mais a mensagem "EMBEDDED OLE OBJECT".

## **Outra Solução**

Se você não quiser remover a mensagem "EMBEDDED OLE OBJECT" abrindo a apresentação no PowerPoint e, em seguida, salvando-a, pode substituir a mensagem pela sua imagem de visualização preferida. O código a seguir demonstra o processo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Adicionar uma imagem aos recursos da apresentação.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Definir um título e a imagem para a visualização do objeto OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O slide contendo o [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/) então muda para isto:

![Nova imagem do objeto OLE](OLE_object_new_image.png)

## **FAQ**

**Por que a mensagem "EMBEDDED OLE OBJECT" aparece?**

A mensagem indica que o objeto OLE foi alterado e sua imagem de visualização precisa ser atualizada. Esse comportamento é intencional.

**Como posso atualizar a visualização no PowerPoint?**

Clique duas vezes na mensagem ou selecione **Object > Edit** para abrir o objeto OLE incorporado. Clique no objeto OLE para atualizar a visualização e, em seguida, salve a apresentação.

**Posso substituir a mensagem sem abrir a apresentação no PowerPoint?**

Sim. Você pode atribuir uma imagem de visualização preferida ao objeto OLE, como mostrado no exemplo de código acima.