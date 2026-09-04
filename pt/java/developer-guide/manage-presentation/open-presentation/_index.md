---
title: Abrir Apresentações em Java
linktitle: Abrir Apresentação
type: docs
weight: 20
url: /pt/java/open-presentation/
keywords:
- abrir PowerPoint
- abrir apresentação
- abrir PPTX
- abrir PPT
- abrir ODP
- carregar apresentação
- carregar PPTX
- carregar PPT
- carregar ODP
- apresentação protegida
- apresentação grande
- recurso externo
- objeto binário
- Java
- Aspose.Slides
description: "Aprenda como abrir apresentações PowerPoint e OpenDocument em Java, fornecer senhas de abertura, controlar o carregamento de recursos e reduzir o uso de memória com Aspose.Slides para Java."
---
## **Introdução**

[Aspose.Slides for Java](https://products.aspose.com/slides/pt/java/) pode carregar apresentações PowerPoint e OpenDocument a partir de arquivos e streams. Depois que uma apresentação é carregada, você pode inspecionar sua estrutura, editar slides, gerenciar recursos e salvá‑la no formato original ou em outro formato suportado.

O comportamento de carregamento pode ser personalizado através da classe [LoadOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/) . Por exemplo, você pode fornecer uma senha de abertura, manter objetos binários grandes fora da memória heap do Java, controlar recursos externos ou omitir dados binários incorporados.

## **Abrir Apresentações**

Para abrir uma apresentação existente, passe o caminho do arquivo ao construtor [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) . Libere a apresentação após o uso para que os manipuladores de arquivo, dados temporários e outros recursos sejam liberados prontamente.

O exemplo Java a seguir mostra como abrir uma apresentação e obter sua contagem de slides:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Abrir Apresentações Protegidas por Senha**

Uma senha de abertura criptografa o conteúdo da apresentação. Para carregar a apresentação completa, passe a senha correta para [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) e forneça as opções ao construtor [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) . O carregamento falha quando a senha está ausente ou incorreta.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Para fluxos de trabalho de detecção, validação e criptografia de senha, veja [Apresentações com Proteção por Senha](/slides/pt/java/password-protected-presentation/). Se uma apresentação criptografada foi deliberadamente salva com propriedades de documento públicas, essas propriedades podem ser lidas sem senha; veja [Gerenciar Propriedades da Apresentação](/slides/pt/java/presentation-properties/).

## **Abrir Apresentações Grandes**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) retorna opções que controlam como Aspose.Slides lida com objetos binários grandes, como imagens, áudio e vídeo. Você pode manter o arquivo fonte bloqueado, permitir arquivos temporários e limitar a quantidade de dados BLOB retidos na memória.

O código Java a seguir demonstra o carregamento de uma apresentação grande (por exemplo, 2 GB):

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Nota" %}}
Com [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked), o arquivo fonte permanece bloqueado até que a instância da apresentação seja descartada. Não mova, sobrescreva ou exclua o arquivo fonte enquanto essa instância estiver ativa.

Aspose.Slides pode copiar o conteúdo de um stream de entrada durante o carregamento. Para apresentações grandes, um caminho de arquivo é, portanto, geralmente mais eficiente que um stream. Veja [Gerenciar BLOBs](/slides/pt/java/manage-blob/) para opções adicionais de armazenamento e gerenciamento de memória.
{{% /alert %}}

## **Controlar Recursos Externos**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) aceita uma implementação de [IResourceLoadingCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iresourceloadingcallback/) . O callback pode fornecer dados de substituição, redirecionar um recurso, usar o carregador padrão ou pular o recurso. Isso é útil quando apresentações contêm imagens externas que precisam ser resolvidas de acordo com regras específicas de segurança ou armazenamento da aplicação.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Carregar Apresentações sem Objetos Binários Incorporados**

Uma apresentação pode conter dados binários incorporados que uma aplicação não necessita ou não deseja manter. Exemplos incluem:

- projetos VBA, disponíveis através de [IPresentation.getVbaProject](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#getVbaProject--);
- dados OLE incorporados, disponíveis através de [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- dados de controle ActiveX, disponíveis através de [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Defina [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) como `true` para remover esses dados binários durante o carregamento. Salve a apresentação carregada para persistir o resultado sanitizado.

Esta opção reduz a exposição a cargas úteis incorporadas indesejadas, mas não é um sistema completo de detecção de malware ou sanitização de conteúdo.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Como posso saber que um arquivo está corrompido e não pode ser aberto?**

Aspose.Slides lança uma exceção de análise ou de formato durante o carregamento. Trate essa falha separadamente de um erro de senha incorreta para que a aplicação possa relatar a causa com precisão.

**O que acontece se as fontes necessárias estiverem ausentes?**

A apresentação ainda pode ser carregada, mas a renderização e exportação podem substituir fontes. Você pode [configurar substituição de fontes](/slides/pt/java/font-substitution/) ou [fornecer fontes personalizadas](/slides/pt/java/custom-font/) para tornar a saída mais previsível.

**Carregar uma apresentação também carrega suas mídias incorporadas?**

Áudios e vídeos incorporados ficam disponíveis através do modelo de objetos da apresentação. Recursos externos são resolvidos de acordo com o comportamento de carregamento de recursos configurado e podem estar indisponíveis se suas localizações não puderem ser acessadas.