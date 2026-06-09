---
title: Gerenciar Projetos VBA em Apresentações Usando Java
linktitle: Apresentação via VBA
type: docs
weight: 250
url: /pt/java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "Descubra como gerar e manipular apresentações PowerPoint e OpenDocument via VBA com Aspose.Slides para Java e otimizar seu fluxo de trabalho."
---
## **Introdução**

Aspose.Slides fornece classes e interfaces para trabalhar com macros e código VBA.

{{% alert title="Note" color="warning" %}} 

Ao converter uma apresentação que contém macros para um formato de arquivo diferente (PDF, HTML, etc.), Aspose.Slides ignora todas as macros (as macros não são transferidas para o arquivo resultante).

Ao adicionar macros a uma apresentação ou ao salvar novamente uma apresentação que contém macros, Aspose.Slides simplesmente grava os bytes das macros.

Aspose.Slides **nunca** executa as macros em uma apresentação.

{{% /alert %}}

## **Adicionar Macros VBA**

Aspose.Slides fornece a classe [VbaProject](https://reference.aspose.com/slides/pt/java/com.aspose.slides/vbaproject/) para permitir que você crie projetos VBA (e referências de projeto) e edite módulos existentes. Você pode usar a interface [IVbaProject](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ivbaproject/) para gerenciar VBA incorporado em uma apresentação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation).
2. Use o construtor [VbaProject](https://reference.aspose.com/slides/pt/java/com.aspose.slides/vbaproject/#VbaProject--) para adicionar um novo projeto VBA.
3. Adicione um módulo ao VbaProject.
4. Defina o código-fonte do módulo.
5. Adicione referências a <stdole>.
6. Adicione referências ao **Microsoft Office**.
7. Associe as referências ao projeto VBA.
8. Salve a apresentação.

Este código Java mostra como adicionar uma macro VBA do zero a uma apresentação:

```java
// Cria uma instância da classe de apresentação
Presentation pres = new Presentation();
try {
    // Cria um novo Projeto VBA
    pres.setVbaProject(new VbaProject());
    
    // Adiciona um módulo vazio ao projeto VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Define o código-fonte do módulo
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Cria uma referência para <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Cria uma referência para Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Adiciona referências ao projeto VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Salva a Apresentação
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Talvez você queira conferir o **Aspose** [Macro Remover](https://products.aspose.app/slides/pt/remove-macros), que é um aplicativo web gratuito usado para remover macros de documentos PowerPoint, Excel e Word. 

{{% /alert %}} 

## **Remover Macros VBA**

Usando a propriedade [VbaProject](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getVbaProject--) da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation), você pode remover uma macro VBA.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) e carregue a apresentação que contém a macro.
2. Acesse o módulo Macro e remova-o.
3. Salve a apresentação modificada.

Este código Java mostra como remover uma macro VBA:

```java
// Carrega a apresentação que contém a macro
Presentation pres = new Presentation("VBA.pptm");
try {
    // Acessa o módulo Vba e o remove 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Salva a Apresentação
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extrair Macros VBA**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) e carregue a apresentação que contém a macro.
2. Verifique se a apresentação contém um Projeto VBA.
3. Percorra todos os módulos contidos no Projeto VBA para visualizar as macros.

Este código Java mostra como extrair macros VBA de uma apresentação que contém macros:

```java
// Carrega a apresentação que contém a macro
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Verifica se a Apresentação contém um Projeto VBA
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Verificar se um Projeto VBA está Protegido por Senha**

Usando o método [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ivbaproject/#isPasswordProtected--), você pode determinar se as propriedades de um projeto estão protegidas por senha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) e carregue uma apresentação que contém uma macro.
2. Verifique se a apresentação contém um [projeto VBA](https://reference.aspose.com/slides/pt/java/com.aspose.slides/vbaproject/).
3. Verifique se o projeto VBA está protegido por senha para visualizar suas propriedades.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Verifique se a apresentação contém um projeto VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**O que acontece com as macros se eu salvar a apresentação como PPTX?**

As macros serão removidas porque o PPTX não oferece suporte a VBA. Para manter as macros, escolha PPTM, PPSM ou POTM.

**A Aspose.Slides pode executar macros dentro de uma apresentação para, por exemplo, atualizar dados?**

Não. A biblioteca nunca executa código VBA; a execução só é possível dentro do PowerPoint com as configurações de segurança adequadas.

**É possível trabalhar com controles ActiveX vinculados a código VBA?**

Sim, você pode acessar controles [ActiveX](/slides/pt/java/activex/) existentes, modificar suas propriedades e removê-los. Isso é útil quando as macros interagem com ActiveX.