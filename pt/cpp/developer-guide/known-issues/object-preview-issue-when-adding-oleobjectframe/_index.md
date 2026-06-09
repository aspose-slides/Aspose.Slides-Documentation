---
title: Problema de Visualização de Objeto ao Adicionar OleObjectFrame
linktitle: Problema de Objeto OLE
type: docs
weight: 10
url: /pt/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de visualização
- incorporar objeto
- incorporar arquivo
- objeto alterado
- visualização do objeto
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Saiba por que o EMBEDDED OLE OBJECT aparece ao adicionar OleObjectFrame no Aspose.Slides para C++ e como corrigir problemas de visualização em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Usando Aspose.Slides para C++, ao adicionar [OleObjectFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/oleobjectframe/) a um slide, uma mensagem "EMBEDDED OLE OBJECT" é exibida no slide de saída. Essa mensagem é intencional e NÃO é um bug.

Para mais informações sobre como trabalhar com objetos OLE, consulte [Manage OLE](/slides/pt/cpp/manage-ole/). 

## **Explicação e Solução**

Aspose.Slides exibe a mensagem "EMBEDDED OLE OBJECT" para notificar que o objeto OLE foi alterado e a imagem de visualização precisa ser atualizada. 

Por exemplo, se você adicionar um gráfico do Microsoft Excel como um [OleObjectFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/oleobjectframe/) a um slide (para mais detalhes, veja o artigo "Manage OLE") e então abrir a apresentação no Microsoft PowerPoint, verá esta imagem no slide:

![OLE object message](OLE_object_message.png)

Se quiser verificar e confirmar que seu objeto OLE foi adicionado ao slide, você deve dar um duplo clique na mensagem "EMBEDDED OLE OBJECT", ou pode clicar com o botão direito sobre ela e usar a opção **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

O PowerPoint então abre o objeto OLE incorporado.

![OLE object data](OLE_object_data.png)

O slide pode permanecer com a mensagem "EMBEDDED OLE OBJECT". Quando você clicar no objeto OLE, a visualização do slide será atualizada e a mensagem "EMBEDDED OLE OBJECT" será substituída pela imagem real do objeto OLE. 

![OLE object preview](OLE_object_preview.png)

Agora, talvez você queira salvar sua apresentação para garantir que a imagem do Objeto OLE seja atualizada corretamente. Dessa forma, após salvar a apresentação, ao abri‑la novamente, você NÃO verá a mensagem "EMBEDDED OLE OBJECT". 

## **Outras Soluções**

### **Solução 1: Substituir a mensagem "Embedded OLE Object" por uma Imagem**

Se você não quiser remover a mensagem "EMBEDDED OLE OBJECT" abrindo a apresentação no PowerPoint e depois salvando‑a, pode substituir a mensagem pela sua imagem de pré‑visualização preferida. Estas linhas de código demonstram o processo:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O slide que contém o `OleObjectFrame` então passa a ficar assim:

![New OLE object image](OLE_object_new_image.png)

### **Solução 2: Criar um Add‑On para PowerPoint**

Você também pode criar um add‑on para o Microsoft PowerPoint que atualiza todos os objetos OLE ao abrir apresentações no programa.