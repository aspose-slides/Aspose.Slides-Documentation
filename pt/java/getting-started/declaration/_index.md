---
title: Requisitos do Gerenciador de Segurança
type: docs
weight: 190
url: /pt/java/declaration/
keywords:
- Gerenciador de Segurança
- política de segurança
- AllPermission
- permissões
- sandbox
- JDK 24
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Quais permissões do Gerenciador de Segurança o Aspose.Slides for Java e o código que o chama precisam no Java 23 e anteriores, e por que não há nada para configurar no Java 24 e posteriores."
---
## **Visão geral**

O Java Security Manager limita o que o código pode fazer de acordo com uma política de segurança. O Java 17 o depreciou para remoção ([JEP 411](https://openjdk.org/jeps/411)), e o Java 24 o desativou permanentemente ([JEP 486](https://openjdk.org/jeps/486)). Este artigo explica o que o Aspose.Slides for Java precisa quando uma aplicação ainda é executada com um Security Manager. Se sua aplicação não habilitar um, o que é o padrão, não há nada a configurar.

## **Java 23 e anteriores**

Quando um Security Manager está habilitado, a política de segurança deve conceder estas permissões ao arquivo JAR do Aspose.Slides e ao código da aplicação que o chama:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides lê propriedades do sistema.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides lê arquivos de fontes e outros arquivos.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides inicia programas do sistema operacional, por exemplo `reg` no Windows e `fc-match` no Linux.
- `java.io.FilePermission` com a ação `write` para as pastas onde sua aplicação salva arquivos.

Conceder as permissões apenas ao arquivo JAR não é suficiente: o código que chama o Aspose.Slides também precisa delas. Conceder `java.security.AllPermission` a ambos também funciona.

Sem a permissão de ler propriedades do sistema ou de iniciar programas, o Aspose.Slides falha na primeira utilização: criar um objeto [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) lança um `ExceptionInInitializerError`. Sem acesso de leitura aos arquivos de fontes, salvar uma apresentação como PDF falha com o erro "Cannot find any fonts installed on the system".

## **Java 24 e posteriores**

O Security Manager não pode ser habilitado no Java 24 e posteriores, portanto não há permissões a conceder. O Aspose.Slides funciona com as permissões da conta que executa sua aplicação. Para restringir o que uma aplicação pode acessar, o projeto OpenJDK recomenda tecnologias fora do JDK, como contêineres, hipervisores e recursos de sandbox do sistema operacional. Veja [JEP 486](https://openjdk.org/jeps/486).

## **FAQ**

**Posso usar o Aspose.Slides em um ambiente que executa aplicações sob uma política restritiva de Security Manager?**

Somente se a política conceder as permissões listadas acima tanto ao Aspose.Slides quanto ao código que o chama. Elas incluem leitura de todos os arquivos e início de qualquer programa.