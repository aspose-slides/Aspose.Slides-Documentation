---
title: Gerenciar Projetos VBA em Apresentações Usando PHP
linktitle: Apresentação via VBA
type: docs
weight: 250
url: /pt/php-java/presentation-via-vba/
keywords:
- macro
- VBA
- macro VBA
- adicionar macro
- remover macro
- extrair macro
- adicionar VBA
- remover VBA
- extrair VBA
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Descubra como gerar e manipular apresentações PowerPoint e OpenDocument via VBA com Aspose.Slides para PHP via Java para otimizar seu fluxo de trabalho."
---
## **Introdução**

A API Aspose.Slides contém classes para trabalhar com macros e código VBA.

{{% alert title="Note" color="warning" %}} 

Ao converter uma apresentação que contém macros para um formato de arquivo diferente (PDF, HTML, etc.), o Aspose.Slides ignora todas as macros (as macros não são transportadas para o arquivo resultante).

Ao adicionar macros a uma apresentação ou ao salvar novamente uma apresentação que contém macros, o Aspose.Slides simplesmente grava os bytes das macros.

O Aspose.Slides **nunca** executa as macros em uma apresentação.

{{% /alert %}}

## **Adicionar Macros VBA**

O Aspose.Slides fornece a classe [VbaProject](https://reference.aspose.com/slides/pt/php-java/aspose.slides/vbaproject/) para permitir que você crie projetos VBA (e referências de projeto) e edite módulos existentes. Você pode usar a classe `VbaProject` para gerenciar VBA incorporado em uma apresentação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
1. Use o construtor [VbaProject](https://reference.aspose.com/slides/pt/php-java/aspose.slides/vbaproject/#VbaProject) para adicionar um novo projeto VBA.
1. Adicione um módulo ao VbaProject.
1. Defina o código-fonte do módulo.
1. Adicione referências a <stdole>.
1. Adicione referências ao **Microsoft Office**.
1. Associe as referências ao projeto VBA.
1. Salve a apresentação.

Este código PHP mostra como adicionar uma macro VBA do zero a uma apresentação:

```php
  # Cria uma instância da classe de apresentação
  $pres = new Presentation();
  try {
    # Cria um novo Projeto VBA
    $pres->setVbaProject(new VbaProject());
    # Adiciona um módulo vazio ao projeto VBA
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Define o código-fonte do módulo
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Cria uma referência a <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Cria uma referência ao Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Adiciona referências ao projeto VBA
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Salva a Apresentação
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Você pode querer conferir o **Aspose** [Macro Remover](https://products.aspose.app/slides/pt/remove-macros), que é um aplicativo web gratuito usado para remover macros de documentos PowerPoint, Excel e Word. 

{{% /alert %}} 

## **Remover Macros VBA**

Usando a propriedade [VbaProject](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getVbaProject) da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation), você pode remover uma macro VBA.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) e carregue a apresentação que contém a macro.
1. Acesse o módulo Macro e remova-o.
1. Salve a apresentação modificada.

Este código PHP mostra como remover uma macro VBA:

```php
  # Carrega a apresentação que contém a macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Acessa o módulo Vba e o remove
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Salva a Apresentação
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extrair Macros VBA**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) e carregue a apresentação que contém a macro.
2. Verifique se a apresentação contém um Projeto VBA.
3. Percorra todos os módulos contidos no Projeto VBA para visualizar as macros.

Este código PHP mostra como extrair macros VBA de uma apresentação que contém macros:

```php
  # Carrega a apresentação que contém a macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Verifica se a Apresentação contém um Projeto VBA
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verificar se um Projeto VBA está Protegido por Senha**

Usando o método [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/pt/php-java/aspose.slides/vbaproject/#isPasswordProtected), você pode determinar se as propriedades de um projeto estão protegidas por senha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e carregue uma apresentação que contém uma macro.
2. Verifique se a apresentação contém um [VBA project](https://reference.aspose.com/slides/pt/php-java/aspose.slides/vbaproject/).
3. Verifique se o projeto VBA está protegido por senha para visualizar suas propriedades.

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Verifique se a apresentação contém um projeto VBA.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**O que acontece com as macros se eu salvar a apresentação como PPTX?**

As macros serão removidas porque o PPTX não suporta VBA. Para manter as macros, escolha PPTM, PPSM ou POTM.

**O Aspose.Slides pode executar macros dentro de uma apresentação para, por exemplo, atualizar dados?**

Não. A biblioteca nunca executa código VBA; a execução só é possível dentro do PowerPoint com as configurações de segurança adequadas.

**É possível trabalhar com controles ActiveX vinculados a código VBA?**

Sim, você pode acessar os [ActiveX controls](/slides/pt/php-java/activex/), modificar suas propriedades e removê-los. Isso é útil quando as macros interagem com ActiveX.