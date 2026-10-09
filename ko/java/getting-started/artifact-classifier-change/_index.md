---
title: 선언
type: docs
weight: 60
url: /ko/java/artifact-classifier-change/
keywords:
- 분류자 Aspose.Slides
- 아티팩트 분류자
- Aspose.Slides 사용
- Aspose.Slides 설치
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java은 이제 jdk16 대신 jdk8 분류자를 사용합니다. 왜 변경되었는지와 종속성을 업데이트하는 방법을 알아보세요."
---
## **`jdk16`에서 `jdk8`(으)로 아티팩트 분류자 변경**

버전 **26.10**부터 게시된 아티팩트에서 사용되는 분류자를 **`jdk16`**(Java 6)에서 **`jdk8`**(Java 8)으로 변경했습니다.

### **변경 사항**

| | 이전 | 이후 |
|---|---|---|
| 분류자 | `jdk16` | `jdk8` |
| 최소 Java 버전 | Java 1.6 | Java 8 |

**이전:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**이후:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **이 변경을 만든 이유**

내부 검토 결과, 더 이상 가치를 제공하지 않고 유지 보수를 방해하는 구버전 Java 지원을 **중단**하기로 결정했습니다. 모든 사용자를 위해 새로운 안정적인 기준선으로 Java 8을 선택했습니다.

이와 함께 실제 최소 지원 버전을 반영하도록 분류자를 업데이트했습니다. 또한 현재 Oracle 명명 규칙에 맞춰 제품을 공식적으로 **JDK 8**이라고 부르도록 정렬했습니다(레거시 `1.8` 형식 대신).

### **수행해야 할 작업**

1. **분류자를** `jdk16`에서 `jdk8`로 변경하십시오.

   **Maven:**
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle:**
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. **런타임 환경**이 Java 8 이상인지 확인하십시오.

3. 이전 분류자를 고정하고 있는 **잠금 파일**이나 종속성 캐시를 새로 고치십시오.

### **마이그레이션 참고: jdk16 및 jdk8**

버전 26.10부터 `jdk16`와 `jdk8` 분류자는 모두 Java 8 호환 JAR을 제공하며(소스/타깃 호환성을 Java 8로 설정), 다음과 같이 동작합니다.

- `jdk16` → 기존 통합을 위한 하위 호환성 유지 목적으로 계속 배포됩니다.
- `jdk8` → Java 8 환경을 위한 새 기본 분류자로 도입되었습니다.

⚠️ Note: 이 이중 배포 단계는 2027년 3월 31일에 종료될 예정입니다. 해당 날짜 이후 `jdk16` 분류자는 폐기되고 `jdk8`만 지원됩니다.

### **호환성 주의사항**

- `jdk16` 분류자는 **2027년 3월 31일** 이후 **더 이상 배포되지 않습니다**.
- 여전히 Java 1.6 지원이 필요하면 마이그레이션이 가능할 때까지 이전 주요 버전 라인을 유지하십시오.

### **도움이 필요하신가요?**

마이그레이션 중 문제가 발생하면 [Aspose 지원](https://forum.aspose.com/)에 문의하여 추가 지원을 받으십시오.